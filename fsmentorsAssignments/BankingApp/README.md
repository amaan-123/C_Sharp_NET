# Problem Statement

Assume you are implementing a Banking Application. Identify entities in the system. Create classes and methods for the various operations in a Bank.

- Use necessary access modifiers and encapsulation techniques to protect the data.
- Use constructors to initialize the objects.
- Use inheritance to create a hierarchy of classes.
- Use abstract classes where necessary.
- Simulate some transactions in the application

# Extension of problem statement

Extend the BankAccount class to include:

- Interest calculation
- Transaction history
- Account types (checking, savings)
- Transfer between accounts

# Required Information

## Checking/Current Account & Overdraft

A current account is a type of bank account designed for frequent transactions, such as deposits, withdrawals, and payments, often used by individuals and businesses for day-to-day financial activities It allows unlimited transactions and typically does not pay interest on the balance

An overdraft is a facility linked to a current account that allows the account holder to withdraw more money than is available in the account, up to a pre-agreed limit This means the account balance can go negative, representing a short-term loan from the bank There are two main types: an arranged (or authorised) overdraft, which is agreed in advance with the bank and usually comes with an interest-free buffer and a set limit, and an unarranged (or unauthorised) overdraft, which occurs when spending exceeds the account balance or the agreed overdraft limit without prior agreement

Arranged overdrafts are typically charged interest only on the amount overdrawn, not the entire limit, and since April 2020, UK banks must apply the same flat annual interest rate (EAR) for both arranged and unarranged overdrafts, eliminating higher fees for unauthorised use Interest is usually charged daily and added monthly Overdrafts can be useful for managing short-term cash flow issues, covering unexpected expenses, or bridging gaps between income and payments However, they are generally more expensive than other borrowing options like personal loans, and prolonged or repeated use can negatively impact a credit score Overdraft limits are determined by the bank based on the customer’s financial situation, credit history, and account activity

# Thinking process — how to approach this assignment

1. **Interpretation** — core requirements: model bank entities, protect data with access modifiers & encapsulation, use constructors, inheritance and abstract classes, and run a short transaction simulation.
2. **Concepts tested** —

   - *Encapsulation*: keep internals private; expose safe read-only or controlled mutators (properties, methods).
   - *Access modifiers*: `private` for internal state, `protected` for subclasses, `public` for API, `internal` for assembly-limited helpers.
   - *Inheritance & abstraction*: provide a common abstract `BankAccount` for shared behavior and force subclasses to implement account-specific rules (interest, overdraft).
   - *Single Responsibility*: separate `Customer`, `BankAccount`, `Transaction`, and `Bank` manager.
3. **Design decisions** —

   - `BankAccount` is `abstract`. It holds balance, transaction history, deposit/withdraw logic and an abstract `CalculateMonthlyInterest()` method.
   - `SavingsAccount` and `CurrentAccount` inherit `BankAccount`. `SavingsAccount` implements interest; `CurrentAccount` implements overdraft behavior.
   - `Transaction` is an immutable record of operations.
   - `Bank` class acts as a simple registry/manager to create accounts and perform transfers.
4. **Safety** — validate amounts, throw exceptions for invalid operations, keep transaction history private and expose read-only views.

---

# Notes on how code maps to OOP concepts

- **Encapsulation**: private fields (`_balance`, `_transactions`, `_customerId`) prevent external code from modifying internal state directly. Public methods (`Deposit`, `Withdraw`, `TransferTo`) provide controlled operations. Transaction list exposed as `IReadOnlyList<Transaction>`.
- **Access modifiers**: `private` for internal data; `protected` for `_balance` so subclasses can modify it safely; `public` for API visible to other parts of program.
- **Constructors**: each class initializes required state (account number, owner, initial deposit). Validation performed in constructors.
- **Inheritance & Abstract class**: `BankAccount` is `abstract` — forces derived classes to implement `CalculateMonthlyInterest()` and share common logic. `SavingsAccount` and `CurrentAccount` override as needed (`Withdraw` override for overdraft).
- **Transaction simulation**: `Main()` runs deposits, withdrawals, transfer, interest application and prints transaction statements.

Use this program as a starting point: extend by adding persistence, account types, fees, monthly statement generation, authentication, or concurrency controls.

# When to use interfaces — short rules

- Use an interface when you need **polymorphism by capability** (different types sharing behavior), **decoupling** (code depends on an abstraction, not a concrete class), or **testability** (you want to mock or stub implementations).
- Use interfaces when you expect **multiple implementations**, when behavior may change independently of data, or when you want to define a **contract** other teams/modules/third-party code can rely on.

# Practical interface candidates for your BankingApp (why each helps)

1. **IAccount** — represents account capability (Deposit, Withdraw, Balance, Transfer).

   - Why: lets services operate on *any* account type (Savings, Current, FixedDeposit) without knowing implementation details; simplifies unit testing and swapping account types.
2. **IInterestCalculator** — encapsulates interest rules (CalculateMonthlyInterest).

   - Why: interest rules change often; different products require different algorithms. Implementations can be swapped, tested independently, or provided per-account via DI.
3. **IAccountRepository (or IAccountStore)** — persistence contract (Get, Add, Update).

   - Why: decouples business logic from storage (in-memory, file, DB). Makes it trivial to replace storage or write integration tests.
4. **ITransferService (or ITransactionService)** — orchestrates transfers and related validations/logging.

   - Why: moving transfer logic out of accounts helps single responsibility and allows centralized rules (limits, fees, audit).
5. **INotificationService** — notify customers (email/SMS/push) on events.

   - Why: notifications are side effects — interface allows mock notifications in tests and many real implementations in production.
6. **IAuditLogger (or ITransactionLogger)** — audit trail interface for security/compliance logging.

   - Why: required separation for compliance; allows plugging different sinks (file, DB, SIEM).
7. **ICustomerRepository** — if customers are stored and retrieved separately.
8. **IAccountFactory** — when account creation rules are nontrivial (product codes, initial offers).

# Which of these make sense *first* for your current code

Start small and high-impact:

1. **IAccount** — convert `BankAccount` to implement it.
2. **IAccountRepository** — makes `Bank`’s internal `_accounts` replaceable/testable.
3. **ITransferService** — move `TransferTo` / transfer orchestration out of `BankAccount`/`Bank`.
4. **IInterestCalculator** — allow injecting interest logic into `SavingsAccount`.

# What exactly to modify in your existing code (step-by-step plan)

Follow this minimal refactor path so you can iterate safely.

### Step 1 — extract `IAccount`

Create an interface matching public behaviors you need externally:

```csharp
public interface IAccount
{
    string AccountNumber { get; }
    Customer Owner { get; }
    decimal Balance { get; }
    IReadOnlyList<Transaction> Transactions { get; }

    void Deposit(decimal amount);
    void Withdraw(decimal amount);
    void ApplyMonthlyInterest();
    // Optional: Transfer is moved to a service; keep only if you prefer in-account transfer
}
```

**Modify** `BankAccount` declaration:

```csharp
public abstract class BankAccount : IAccount
{
    // no change to internal logic required; just add ": IAccount"
}
```

**Why**: callers now depend on `IAccount` not `BankAccount`.

---

### Step 2 — introduce `IAccountRepository`

Define:

```csharp
public interface IAccountRepository
{
    void Add(IAccount account);
    IAccount? Get(string accountNumber);
    IEnumerable<IAccount> GetAll();
    void Update(IAccount account);
}
```

**Implementations**:

- `InMemoryAccountRepository` (initial, very small change — wraps your `_accounts` dictionary).
- Later: `SqlAccountRepository` for DB persistence.

**Modify** `Bank` to use `IAccountRepository` (constructor injection):

```csharp
public class Bank
{
    private readonly IAccountRepository _repo;

    public Bank(IAccountRepository repo)
    {
        _repo = repo;
    }

    public BankAccount CreateSavingsAccount(...){
        var acc = new SavingsAccount(...);
        _repo.Add(acc);
        return acc;
    }

    public IAccount? GetAccount(string accountNumber) => _repo.Get(accountNumber);
}
```

**Why**: `Bank` no longer owns storage; tests can pass a fake repo.

---

### Step 3 — move transfer logic into `ITransferService`

Define:

```csharp
public interface ITransferService
{
    void Transfer(IAccount from, IAccount to, decimal amount, string? note = null);
}
```

Implement `TransferService` which uses repository, validator, and audit logger. Move the transfer orchestration (withdraw + deposit + two transaction records) here. Replace previous `Bank.Transfer` to call `ITransferService`.

**Why**: Single responsibility and central place for business rules (limits, fees, atomicity).

---

### Step 4 — use `IInterestCalculator`

Define:

```csharp
public interface IInterestCalculator
{
    decimal CalculateMonthlyInterest(IAccount account);
}
```

- Provide `SavingsInterestCalculator` implementation.
- Inject into `SavingsAccount` (constructor) or into the service that applies interest across accounts.

Modify `SavingsAccount` to call injected `IInterestCalculator` rather than implementing logic inside the account.

**Why**: interest policy can evolve without changing account types.

---

### Step 5 — add `INotificationService` & `IAuditLogger` (optional now)

Define simple interfaces:

```csharp
public interface INotificationService { void Notify(Customer c, string message); }
public interface IAuditLogger { void Log(string eventText); }
```

Call these from `TransferService`, `Account` events, or `Bank` to externalize side effects.

# Example: minimal code snippets showing the changes

`IAccount`:

```csharp
public interface IAccount
{
    string AccountNumber { get; }
    Customer Owner { get; }
    decimal Balance { get; }
    IReadOnlyList<Transaction> Transactions { get; }

    void Deposit(decimal amount);
    void Withdraw(decimal amount);
    void ApplyMonthlyInterest();
}
```

`IAccountRepository` implementation (in-memory):

```csharp
public class InMemoryAccountRepository : IAccountRepository
{
    private readonly Dictionary<string, IAccount> _store = new();

    public void Add(IAccount account) => _store.Add(account.AccountNumber, account);
    public IAccount? Get(string accountNumber) => _store.TryGetValue(accountNumber, out var a) ? a : null;
    public IEnumerable<IAccount> GetAll() => _store.Values;
    public void Update(IAccount account) => _store[account.AccountNumber] = account;
}
```

`ITransferService`:

```csharp
public class TransferService : ITransferService
{
    private readonly IAuditLogger _audit;
    public TransferService(IAuditLogger audit) { _audit = audit; }

    public void Transfer(IAccount from, IAccount to, decimal amount, string? note = null)
    {
        if (from == null || to == null) throw new ArgumentNullException();
        if (amount <= 0) throw new ArgumentException("Amount must be > 0");

        // withdraw may throw if insufficient or overdraft rules block it
        from.Withdraw(amount);
        from.GetType(); // optional: additional checks

        to.Deposit(amount);

        _audit?.Log($"Transfer {amount:C} from {from.AccountNumber} to {to.AccountNumber} note:{note}");
    }
}
```

# How these changes affect your existing code (concrete list)

- Add new interface files (IAccount, IAccountRepository, ITransferService, IInterestCalculator, etc.).
- Change `BankAccount` class signature to `: IAccount` (no further change needed).
- Replace direct `_accounts` dictionary in `Bank` with an `IAccountRepository` dependency — update constructors and calls.
- Remove or deprecate `TransferTo` method on `BankAccount` (or keep as convenience that calls `ITransferService`), and implement transfer orchestration inside `TransferService`.
- Inject `IInterestCalculator` into `SavingsAccount` (or move interest application to a dedicated service that iterates accounts and applies calculators).
- Add simple implementations for `InMemoryAccountRepository` and `ConsoleAuditLogger` for tests/demos.
- Update `Program.Main` to wire dependencies (manually or via a DI container):

  ```csharp
  var repo = new InMemoryAccountRepository();
  var audit = new ConsoleAuditLogger();
  var transferService = new TransferService(audit);

  var bank = new Bank(repo, transferService); // Bank gets repo & transfer service
  ```

- Update unit tests to mock `IAccount`, `IAccountRepository`, `ITransferService` as required.

# How to refactor safely (recommended workflow)

1. **Add interfaces first** (without changing behavior). Add `IAccount` and `IAccountRepository` files.
2. **Make `BankAccount` implement `IAccount`** (compiler-safe). Keep existing logic.
3. **Add `InMemoryAccountRepository`** and change `Bank` constructor to accept `IAccountRepository`. Keep old code path for a short time and run tests.
4. **Introduce `ITransferService`**, implement it, then change callers (`Bank.Transfer`) to use it. Keep `TransferTo` as wrapper until fully tested.
5. **Introduce tests** and use mocks to validate behavior (example: assert `TransferService` calls `Withdraw` on source and `Deposit` on destination).
6. **Extract interest logic** to `IInterestCalculator` and inject it.
7. **Remove redundant code** (old transfer method or direct repository accesses) after tests pass.

# Benefits you will get (explicit)

- **Testability**: you can unit test services by mocking interfaces.
- **Flexibility**: add new account products without changing services.
- **Separation of concerns**: business rules vs persistence vs side effects.
- **Safer refactoring**: small interface contracts reduce ripple effect in the codebase.

# Quick checklist to implement now

- [ ] Create `IAccount` and update `BankAccount : IAccount`.
- [ ] Add `IAccountRepository` + `InMemoryAccountRepository`. Change `Bank` to use the repository.
- [ ] Create `ITransferService` and move `Transfer` logic into it. Update `Bank.Transfer` to call the service.
- [ ] Add `IAuditLogger` and `INotificationService` stubs and call them from `TransferService`.
- [ ] Optionally extract `IInterestCalculator` and inject into `SavingsAccount` (or a scheduler service).
- [ ] Add unit tests that mock these interfaces.
