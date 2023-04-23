using Microsoft.AspNetCore.Mvc;
using TransactionManagement.BLL.Models;
using TransactionManagement.BLL.Services.Interfaces;

namespace TransactionManagement.Web.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        // GET: TransactionsController
        public async Task<ActionResult> Index()
        {
            var transactions = await _transactionService.GetAllAsync();
            return View(transactions);
        }

        // GET: TransactionsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var transaction = await _transactionService.GetAsync(id);
            return View(transaction);
        }

        // GET: TransactionsController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: TransactionsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TransactionModel model)
        {
            await _transactionService.CreateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: TransactionsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var transaction = await _transactionService.GetAsync(id);
            return View(transaction);
        }

        // POST: TransactionsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, TransactionModel model)
        {
            await _transactionService.UpdateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: TransactionsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var transaction = await _transactionService.GetAsync(id);
            return View(transaction);
        }

        // POST: TransactionsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, TransactionModel model)
        {
            await _transactionService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
