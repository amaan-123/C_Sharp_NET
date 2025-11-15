<!-- Transaction questions -->
## Q) Why did we use enum TransactionType?

## A) **Reason:** The `enum TransactionType` is used to make the code **safer, clearer, and more maintainable** when representing the *kind* of transaction

```csharp
public enum TransactionType
{
    Deposit,
    Withdrawal,
    TransferIn,
    TransferOut,
    Interest
}
```

Below is the precise reasoning.

---

### 1) To avoid “magic strings”

Without an enum, you might write:

```csharp
new Transaction("deposit", amount, balance);
new Transaction("Deposit", amount, balance);
new Transaction("DEPOSIT", amount, balance);
```

These create problems:

* Typos not caught by compiler (`"depsoit"`)
* No consistency
* No guarantee of valid values

**Enums enforce correctness at compile time.**

---

### 2) To restrict possible values

An enum gives a **closed set of allowed transaction types**.

You cannot accidentally create:

```csharp
TransactionType t = (TransactionType)999;
```

or a random string.

All valid values are defined in one place.
This improves correctness and prevents invalid states.

---

### 3) To make code more readable

This:

```csharp
new Transaction(TransactionType.Deposit, amount, balance);
```

is more expressive and self-documenting than:

```csharp
new Transaction("deposit", amount, balance);
```

Enums act like named constants → easier for humans to understand.

---

### 4) To make switching/branching logic reliable

Enums support clean switch statements:

```csharp
switch(t.Type)
{
    case TransactionType.Deposit:
    case TransactionType.TransferIn:
    case TransactionType.Withdrawal:
        ...
}
```

Strings break easily and need comparison logic (`Equals`, casing, trimming, etc.).

---

### 5) To support stronger type checking

The compiler ensures you only pass a **TransactionType** wherever required.

This prevents:

```csharp
new Transaction(123, amount, balance);
new Transaction("BankHoliday", amount, balance);
```

---

### 6) To maintain uniformity in reporting & UI

When printing statements:

```csharp
Console.WriteLine(t.Type);
```

C# automatically prints:

```
Deposit
Withdrawal
TransferOut
```

Consistent formatting — always the same string.

---

### 7) To make future extension easy

If the bank adds:

* ServiceCharge
* ATMWithdrawal
* UPITransfer
* LostCardFee

…you only add them to the enum and the rest of the system benefits.

---

### Summary

**We use `enum TransactionType` because it:**

* Prevents mistakes
* Gives compile-time safety
* Avoids magic strings
* Makes code clean and expressive
* Simplifies logic when switching and comparing
* Makes the domain model more precise
* Supports easy future expansion

## Q) When we already have a private readonly List<Transaction> _transactions, why create a public IReadOnlyList<Transaction> Transactions? Why use the AsReadOnly() method on it?

## A)

### 1) Why expose `IReadOnlyList<Transaction>` when you already have a private `List<Transaction>`?

Because you want **encapsulation + safe read access**.

Inside the class:

```csharp
private readonly List<Transaction> _transactions = new List<Transaction>();
```

The list must remain **private** because:

* Only the class should modify it.
* No external code should be able to add, remove, or alter transactions.
* This preserves data integrity.

However, the outside world *must* be able to **view** transactions (bank statements, logs, UI).

Therefore the class exposes:

```csharp
public IReadOnlyList<Transaction> Transactions => _transactions.AsReadOnly();
```

This gives:

* Read-only access to the caller.
* Full write access inside the class.

---

### 2) Why not return the original list directly?

If you did:

```csharp
public List<Transaction> Transactions => _transactions;
```

External code could do dangerous things:

```csharp
account.Transactions.Clear();
account.Transactions.Add(new Transaction(...));
account.Transactions[0] = null;
```

This breaks:

* Transaction history correctness
* Accounting integrity
* Immutable audit trail

Returning the original list **exposes internal structure** → violates encapsulation.

---

### 3) Why `IReadOnlyList<T>`?

Because it guarantees:

* Caller can **read** values (index, enumeration).
* Caller **cannot modify** (no Add, Remove, Clear).

It is the ideal public-facing view for a history log.

Also:

* It’s an interface — easy to test, mock, or replace.
* Works with any collection that supports read-only access.

---

### 4) Why use `AsReadOnly()`?

`AsReadOnly()` returns a **read-only wrapper** around the list.

Important:
It does **not copy the list**. It wraps it.

So when the list changes internally:

```csharp
_transactions.Add(new Transaction(...));
```

The read-only view **automatically reflects the update**.

This is exactly what you want:

* Caller sees updates.
* Caller cannot modify history.

---

### 5) Why not return `Enumerable` or an array?

#### Why not return `IEnumerable<Transaction>`?

Because the caller might still do:

```csharp
account.Transactions.ToList().Clear(); // modifies only copy but misleading
```

Or you lose indexing capabilities.

#### Why not return an array?

Returning a new array each time is:

* Expensive (copying)
* Not live-updated
* Easy to misuse

`IReadOnlyList` + `AsReadOnly()` provides:

* Safety
* Efficiency
* Live updates
* Proper abstraction

---

### Summary

| Purpose                               | Explanation                                                       |
| ------------------------------------- | ----------------------------------------------------------------- |
| **Private List<Transaction>**         | Internal storage and modification allowed only inside class       |
| **Public IReadOnlyList<Transaction>** | Safe read-only access to callers                                  |
| **AsReadOnly()**                      | Wraps the list so outside code cannot change it, but sees updates |

This is a standard C# pattern for **encapsulation + safe collections**.

---

<!-- Common questions b/w masterclass.md & this code. -->

## Q) Explain each aspect of difference between the following two ways & why/when to use each? (`readonly`, the `=>`, `private set`)

```csharp
// way 1(used)
private readonly string _accountNumber;
public string AccountNumber =>_accountNumber;

// Protected so derived classes can access balance safely
protected decimal _balance;
// Expose balance read-only to outside
public decimal Balance => _balance;

```

```csharp
// way 2
public string AccountNumber { get; private set; }

private decimal balance;
public decimal Balance
{
    get { return balance; }
    private set { balance = value; }
}
```

## A) This comparison gets right to the heart of how **fields, properties, accessors, and immutability** work together in C\#

Let’s unpack it systematically and then summarize when to prefer each **style (Way 1 vs Way 2)**.

---

### 🟩 1. `readonly` field (in Way 1)

#### **Meaning**

* Declared using `readonly` before the field type.
* Can only be **assigned once**:

  * either **at declaration**, or
  * inside a **constructor**.
* After that, the value is **immutable** for the lifetime of the object.

```csharp
private readonly string _accountNumber;

public Account(string acc)
{
    _accountNumber = acc; // allowed
}
```

#### **Why/when to use**

* You want **true immutability** after construction.
* The value should **never change**, even inside the class itself.
* Common in **domain models**, **value objects**, or anywhere identity data should not mutate (like account numbers, IDs, GUIDs).

#### **In contrast**

* A private setter property (`{ get; private set; }`) can still be reassigned **inside the class**, breaking immutability.

---

### 🟩 2. Expression-bodied property (`=>`)

#### **Meaning**

* The `=>` syntax is a *shorthand* for a property or method that returns a single expression.
* It’s *syntactic sugar* only; it behaves like a normal getter.

```csharp
public string AccountNumber => _accountNumber;
```

is equivalent to:

```csharp
public string AccountNumber
{
    get { return _accountNumber; }
}
```

#### **Why/when to use**

* Ideal for **read-only**, simple return properties.
* Clean, concise code for immutable or computed values.
* Especially suited for properties that return constants or derived calculations.

**Example:**

```csharp
public decimal AnnualInterest => _balance * 0.05m;
```

---

### 🟩 3. `private set` accessor (in Way 2)

#### **Meaning**

* Property has both a getter and a setter, but the setter’s access level is limited (private).
* External code cannot modify the property, but the **class itself can**.

```csharp
public string AccountNumber { get; private set; }
```

#### **Why/when to use**

* You want **encapsulation** (control who modifies values) but **not immutability**.
* The property value can change **inside the class** (e.g., through a method or constructor logic) but **not externally**.

**Example:**

```csharp
public void ResetAccountNumber(string newNumber)
{
    AccountNumber = newNumber; // allowed
}
```

This approach is common in **entity classes** (like ORM models) where frameworks like Entity Framework need to set private values during data materialization.

---

### 🟩 4. The `protected` field in Way 1

```csharp
protected decimal _balance;
public decimal Balance => _balance;
```

#### **Meaning**

* `protected` makes `_balance` accessible to derived classes, not just this class.
* The public `Balance` property exposes it read-only to the outside.

#### **Why/when to use**

* The class hierarchy (e.g., subclasses of `Account`) needs to modify `_balance` internally.
* External code (like client UI) should not directly set balance — ensuring **controlled modification** through business rules or methods like `Deposit()` and `Withdraw()`.

---

### 🟩 Comparison Summary

| Aspect                | **Way 1**                               | **Way 2**                                       |
| --------------------- | --------------------------------------- | ----------------------------------------------- |
| **Field declaration** | `readonly` field for immutability       | Backing field (`balance`) for mutable state     |
| **Property type**     | Expression-bodied getter (`=>`)         | Full property syntax with private setter        |
| **Mutability**        | Value can’t change after constructor    | Value can change *inside the class*             |
| **Encapsulation**     | Exposes field via read-only property    | Encapsulates value fully with controlled access |
| **Setter control**    | No setter at all                        | Has a setter but `private`                      |
| **Inheritance use**   | `protected` allows derived access       | `private` limits access to base class only      |
| **Typical usage**     | Immutable or domain-value objects       | Mutable entities, DTOs, ORM models              |
| **Example domains**   | Banking account number, constant config | Updatable balance, last login date, counters    |

---

### 🟦 Real-world usage patterns

#### ✅ Use **Way 1 (readonly + =>)** when

* The property value must **never change** after construction.
* You want **immutable** design (e.g., `AccountNumber`, `Id`, `CreatedOn`).
* You prefer concise syntax and don’t need framework binding (like EF Core).

#### ✅ Use **Way 2 (get; private set;)** when

* The property value may **change internally** as part of class behavior.
* You need framework compatibility (e.g., ORM reflection, serialization).
* You want to allow **controlled mutation** inside the class only.

---

#### Example combined pattern (real-world hybrid)

```csharp
public class Account
{
    public string AccountNumber { get; }              // immutable
    public decimal Balance { get; private set; }      // mutable inside class

    public Account(string accNo, decimal initial)
    {
        AccountNumber = accNo;
        Balance = initial;
    }

    public void Deposit(decimal amount) => Balance += amount;
    public void Withdraw(decimal amount) => Balance -= amount;
}
```

**Why it works well:**

* `AccountNumber` stays fixed (`readonly` behavior through `get;` only).
* `Balance` can change safely within the class using business logic.

---

#### ✅ Key Takeaway

* `readonly` = compile-time immutability guarantee (field-level).
* `=>` = concise syntax for single-expression getter (no logic).
* `private set` = controlled internal mutability (property-level).

Together, they let you **precisely control data exposure and immutability** — a core practice in professional C# class design.

## Q) In a constructor(like in the Customer constructor) when do you assign a value to a private field (like _customerId) vs when to it's property(like for FullName & Address)

## A) Use this rule

### 1. Assign **directly to the private field** when

* The value **must not be changed later**.
* The value **does not require any validation logic** in the property setter.
* The value is intended to be **read-only publicly**, so only the constructor should set it.

**Example: `_customerId`**

```csharp
private readonly string _customerId;
public string CustomerId => _customerId;

public Customer(string id, string fullName)
{
    _customerId = id;     // correct: fixed, no future change allowed
    FullName = fullName;  // property: must be validated
}
```

Why assign to the field?

* `CustomerId` has **no setter**.
* It is meant to be **immutable** after the object is created.
* No need for a property setter; assigning to the field is enough.

---

### 2. Assign **through the property** when

* The property setter contains **validation** or **normalization**.
* You expect the value may be **changed later**, so consistency matters.
* You want to reuse setter logic inside the constructor to avoid duplication.

**Example: `FullName` and `Address`**

```csharp
private string _fullName;
public string FullName
{
    get => _fullName;
    set
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Name cannot be empty.");
        _fullName = value.Trim();
    }
}
```

Constructor:

```csharp
public Customer(string id, string fullName, string? address = null)
{
    _customerId = id;   // fixed for lifetime
    FullName = fullName;   // uses validation
    Address = address;     // uses normalization
}
```

Why assign via the property?

* Validation in the setter ensures bad names/addresses never enter the object.
* Constructor becomes cleaner.
* Consistency: all writes go through the setter logic.

---

### Summary Table

| Case                                      | Assign to Private Field? | Assign via Property Setter? |
| ----------------------------------------- | ------------------------ | --------------------------- |
| Value is immutable after creation         | Yes                      | No                          |
| No validation/logic needed                | Yes                      | No                          |
| Property setter includes validation/logic | No                       | Yes                         |
| Property value may change later           | No                       | Yes                         |
| Want consistent validation in constructor | No                       | Yes                         |

---

## Q) How to decide on creating a Customer object passed as parameter to account creation methods by introducing a corresponding Owner property in BankAccount instead of just a regular Owner property assigned via constructor? Also, what is `nameof` like in

```csharp
Owner = owner ?? throw new ArgumentNullException(nameof(owner));
```

## A)

### 1) Why create a **Customer object** and pass it into the `BankAccount` constructor?

This is a **design decision**:
You use a *Customer object* when the “owner” isn’t just a simple string, but a **real entity with its own data and behavior**.

#### Use a `Customer` class when

* The owner has **attributes** (Name, ID, Address, Phone, KYC, etc.).
* You want to **reuse customer data across multiple accounts**.
* You want to **avoid duplicating customer information** inside every account.
* You want the relationship: **one customer → many accounts**.
* You want the BankAccount object to depend on a *rich object* instead of simple fields.

#### Why store it as a **property** in `BankAccount`?

Because every account needs to know *who it belongs to*.

```csharp
public Customer Owner { get; }
```

Keeping the reference gives:

* Read-only assurance: account’s owner cannot be changed after creation.
* Type safety: `Owner` is always a full `Customer` object, never random strings.
* Better modeling: BankAccount “has a” Customer → **composition**.

#### Incorrect alternative

Passing a name or customer ID only:

```csharp
public string OwnerName;  // bad — not a real entity
```

This loses structure, validation, relationships, and future extensibility.

---

### 2) Why pass the **Customer object** into the constructor?

Because you want the account created in a **valid state** from the beginning.

```csharp
public BankAccount(string accountNumber, Customer owner, decimal initialDeposit)
{
    Owner = owner ?? throw new ArgumentNullException(nameof(owner));
}
```

If you allowed:

```csharp
Owner = null;
```

The whole object becomes invalid:

* Who owns the account?
* How to print statements?
* How to link transactions to a user?

Embedding the `Customer` reference **enforces correctness** at creation.

---

### 3) What does `nameof(owner)` mean?

`nameof(x)` returns the **string literal name** of the variable/class/member **as written in code**, not its value.

#### Example

```csharp
nameof(owner)
```

returns the string:

```
"owner"
```

So this line:

```csharp
throw new ArgumentNullException(nameof(owner));
```

is equivalent to:

```csharp
throw new ArgumentNullException("owner");
```

#### Why use `nameof` instead of using a string?

1. **Refactor-safe**
   If you rename the parameter from `owner` → `customerOwner`,
   `nameof(owner)` automatically updates.

2. **Avoids typos**
   `"owenr"` → compiler cannot catch this.
   `nameof(owner)` → compiler ensures correctness.

3. **Clean, maintainable, self-validating code**
   Everywhere you need the *name* of something in code (logs, throwing exceptions, attributes), `nameof` is the correct tool.

---

### 4) Summary decision guide

#### Create a `Customer` object and store it as `Owner` when

* The owner is a real domain entity.
* You need to store structured data.
* You want multiple accounts linked to the same customer.
* You want validation and behavior inside the `Customer` class.

#### Use `nameof` when

* Throwing exceptions.
* Logging parameter/property names.
* Avoiding string-literal bugs.
* Making code resilient to renaming.

---

## Q) What is the following concept called(Constructor(parameters) : base(parameters))? Why & when to use it?

```csharp
public SavingsAccount(string accountNumber, Customer owner, decimal initialDeposit, decimal annualInterestRate) : base(accountNumber, owner, initialDeposit){

}
```

## A) This is the **base constructor call** (also called *constructor chaining to the base class constructor*)

Syntax:

```csharp
public Derived(...params...) : base(...params...)
```

It tells C# to **first run the parent class’s constructor** before running the derived class’s constructor body.

---

### Why it is needed

A derived class inherits fields and behavior from its base class, but the **base class controls how its internal private fields must be initialized**.

Example:
`SavingsAccount` inherits from `BankAccount`.
Only `BankAccount` knows how to correctly initialize:

* `_accountNumber`
* `_balance`
* `_transactions`
* owner assignment
* validation for initial deposit
* transaction recording logic

Since these members are **private and protected**, the derived class **cannot** set them manually.

Therefore, the derived class must *delegate* initialization upward:

```csharp
: base(accountNumber, owner, initialDeposit)
```

This guarantees the object starts in a **valid state**.

---

### When to use `: base(...)`

Use a base constructor call whenever:

1. **Your base class has a constructor that requires parameters.**
   Example:
   `BankAccount` cannot be created without account number, owner, and deposit.

2. **The derived class should rely on the base class to initialize its part of the object.**
   You want consistent, centralized initialization logic.

3. **You want to prevent duplicate code.**
   You don’t want to rewrite validation and setup logic in every subclass.

4. **Your derived class adds only extra fields or behavior, not fundamental initialization.**

---

### What happens under the hood

For this:

```csharp
public SavingsAccount(...) : base(accountNumber, owner, initialDeposit)
{
    _annualInterestRate = annualInterestRate;
}
```

Execution order:

1. Call to `BankAccount` constructor:

   * validates account number
   * assigns `Owner`
   * sets `_balance`
   * records initial deposit transaction
   * sets up transaction list

2. After that completes, return to `SavingsAccount` constructor body:

   * only initialize `_annualInterestRate`.

If you didn’t call `base(...)`, the compiler would error because the base class **requires arguments**.

---

### When `: base()` is optional

Only when the base class has a **parameterless constructor**.

Example:

```csharp
public class A
{
    public A() {}         // parameterless
}

public class B : A
{
    public B() {}        // calls base() implicitly
}
```

But if the base constructor requires parameters, derived constructors must explicitly pass them.

---

### Summary (compact)

* **Name**: Base constructor call (constructor chaining).
* **Purpose**: Delegate initialization to the base class so it sets up its own fields correctly.
* **Use when**:

  * Base class has a parameterized constructor.
  * Base class controls part of the object’s state.
  * Avoiding duplicate initialization logic.
* **Effect**: Base constructor runs first → derived constructor runs next.

---

<!-- Bank questions: -->

## Q) Why is a Dictionary suitable for keeping data of the bank accounts in the bank? What is TryGetValue() method?

## A) 1) Why is a **Dictionary** suitable for storing bank accounts?

A bank needs to look up accounts **fast**, **uniquely**, and **reliably**, based on the **account number**.

A `Dictionary<string, BankAccount>` is ideal because:

---

#### A) Fast lookup (O(1) average time)

When a user performs:

* deposit
* withdrawal
* transfer
* statement generation

…the bank must instantly find the correct account.

With a dictionary:

```csharp
_accounts[accountNumber]
```

is a **constant-time** lookup.
No searching, no scanning, instant access.

If you used a list:

```csharp
foreach (var acc in accounts)
    if(acc.AccountNumber == inputNumber)
```

This is **O(n)** — slow as accounts grow.

---

#### B) Account numbers are unique → perfect dictionary keys

Each account has a *guaranteed unique ID*, so a dictionary key is natural.

```csharp
_accounts.Add(accountNumber, account);
```

Using a dictionary automatically enforces:

* no duplicate keys
* safe retrieval
* consistent mapping

---

#### C) Easy to check existence

Before creating or transferring:

```csharp
if (_accounts.ContainsKey(accNum)) …
```

Safe and simple.

---

#### D) Natural “map” relationship

A bank behaves like a mapping:

```
AccountNumber → AccountObject
```

Dictionaries are designed exactly for such relationships.

---

#### E) Cleaner code

Using a dictionary avoids:

* manual searching
* custom indexing
* buggy code
* unnecessary loops

It keeps the `Bank` class clean and efficient.

---

### 2) What is `TryGetValue()`?

`TryGetValue()` is a **safe way to retrieve a value from a dictionary** without risking exceptions.

Signature:

```csharp
public bool TryGetValue(TKey key, out TValue value)
```

#### Why we use it

* It **does not throw** if the key doesn't exist.
* Instead, it returns:

  * `true` if found → gives you the value
  * `false` if not found → avoids errors

#### Example

```csharp
if (_accounts.TryGetValue(accountNumber, out var account))
{
    Console.WriteLine("Found account: " + account.Owner.FullName);
}
else
{
    Console.WriteLine("Account not found.");
}
```

#### Compare with indexer

```csharp
var acc = _accounts[accountNumber]; // throws KeyNotFoundException if missing
```

So `TryGetValue()` is the safe, recommended pattern.

---

#### Summary

##### Why Dictionary?

* Fast lookups
* Unique keys
* Simple existence checks
* Perfect mapping from ID → object
* Scalable for large number of accounts

##### What is TryGetValue?

* Safe key lookup
* Avoids exceptions
* Returns boolean for success
* Provides output only when key exists

---
