using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BibliotecaWeb.Models;

namespace BibliotecaWeb.Controllers
{
    public class EmprestimosController : Controller
    {
        private readonly Contexto _context;

        public EmprestimosController(Contexto context)
        {
            _context = context;
        }

        // GET: Emprestimos
        public async Task<IActionResult> Index()
        {
            var contexto = _context.emprestimo.Include(e => e.livro).Include(e => e.usuario);
            return View(await contexto.ToListAsync());
        }

        // GET: Emprestimos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.emprestimo
                .Include(e => e.livro)
                .Include(e => e.usuario)
                .FirstOrDefaultAsync(m => m.emprestimoId == id);
            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        // GET: Emprestimos/Create
        public IActionResult Create()
        {
            ViewData["livroId"] = new SelectList(_context.livro, "livroId", "titulo");
            ViewData["usuarioId"] = new SelectList(_context.usuario, "usuarioId", "cpf");
            return View();
        }

        // POST: Emprestimos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("emprestimoId,usuarioId,livroId,dataEmprestimo,dataDevolucao")] Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {
                var livro = await _context.livro.FindAsync(emprestimo.livroId);

                // Verifica se o livro existe e se há estoque disponível
                if (livro == null || livro.quantiaEstoque <= 0)
                {
                    ModelState.AddModelError("", "Livro não disponível para empréstimo.");
                    ViewData["livroId"] = new SelectList(_context.livro, "livroId", "titulo", emprestimo.livroId);
                    ViewData["usuarioId"] = new SelectList(_context.usuario, "usuarioId", "cpf", emprestimo.usuarioId);
                    return View(emprestimo);
                }

                // Adiciona o empréstimo ao contexto
                _context.Add(emprestimo);

                // Diminui a quantidade do livro
                livro.quantiaEstoque--;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["livroId"] = new SelectList(_context.livro, "livroId", "titulo", emprestimo.livroId);
            ViewData["usuarioId"] = new SelectList(_context.usuario, "usuarioId", "cpf", emprestimo.usuarioId);
            return View(emprestimo);
        }

        // GET: Emprestimos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.emprestimo.FindAsync(id);
            if (emprestimo == null)
            {
                return NotFound();
            }
            ViewData["livroId"] = new SelectList(_context.livro, "livroId", "titulo", emprestimo.livroId);
            ViewData["usuarioId"] = new SelectList(_context.usuario, "usuarioId", "cpf", emprestimo.usuarioId);
            return View(emprestimo);
        }

        // POST: Emprestimos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("emprestimoId,usuarioId,livroId,dataEmprestimo,dataDevolucao")] Emprestimo emprestimo)
        {
            if (id != emprestimo.emprestimoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emprestimo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmprestimoExists(emprestimo.emprestimoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["livroId"] = new SelectList(_context.livro, "livroId", "titulo", emprestimo.livroId);
            ViewData["usuarioId"] = new SelectList(_context.usuario, "usuarioId", "cpf", emprestimo.usuarioId);
            return View(emprestimo);
        }

        // GET: Emprestimos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.emprestimo
                .Include(e => e.livro)
                .Include(e => e.usuario)
                .FirstOrDefaultAsync(m => m.emprestimoId == id);
            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        // POST: Emprestimos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emprestimo = await _context.emprestimo.FindAsync(id);
            if (emprestimo != null)
            {
                _context.emprestimo.Remove(emprestimo);

                // Aqui você pode adicionar lógica para reverter a quantidade do livro se necessário
                var livro = await _context.livro.FindAsync(emprestimo.livroId);
                if (livro != null)
                {
                    livro.quantiaEstoque++;
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmprestimoExists(int id)
        {
            return _context.emprestimo.Any(e => e.emprestimoId == id);
        }
    }
}
