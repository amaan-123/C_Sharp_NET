using Microsoft.AspNetCore.Mvc;
using SchoolSheetReceiver.Models;
using System.Collections.Generic;

namespace SchoolSheetReceiver.Controllers
{
    public class SheetController : Controller
    {
        // Static list acts as a temporary in-memory database
        private static List<SheetSubmission> _submissions = new List<SheetSubmission>();

        // 1. THE VIEW: Shows the table of received submissions
        // URL: /Sheet
        public IActionResult Index()
        {
            // Reverse list to show newest first
            var list = _submissions.OrderByDescending(x => x.SubmittedOn).ToList();
            return View(list);
        }

        // 2. THE API: Receives data from Google Sheets
        // URL: /api/receivesheet
        [HttpPost("api/receivesheet")]
        public IActionResult Receive([FromBody] SheetSubmission data)
        {
            if (data == null)
            {
                return BadRequest("Payload is null");
            }

            // Save to memory
            _submissions.Add(data);

            // Log to console so you see it happening in terminal
            Console.WriteLine($"[RECEIVED] Submission from {data.SubmittedBy} at {data.SubmittedOn}");

            return Ok(new { message = "Data received successfully" });
        }
    }
}