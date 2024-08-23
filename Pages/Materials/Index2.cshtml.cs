using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Almacenes.Data;
using Almacenes.Models;
using System.Drawing.Text;
using Microsoft.Identity.Client;
using Almacenes.Interfaces;
using Almacenes.ViewModels;

namespace Almacenes.Pages.Materials
{
    public class Index2Model : PageModel
    {
        private readonly AlmacenesContext _context;
        //private readonly IMaterialBalance _balance;

        public Index2Model(AlmacenesContext context/*, IMaterialBalance balance*/)
        {
            _context = context;
            //_balance = balance;
        }

        [BindProperty(SupportsGet = true)]
        public List<Material> Material { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public List<Movimiento> Movimientos { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public List<MaterialMovimientosVM> MaterialMovimientosVMs { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public IEnumerable<IGrouping<int, Movimiento>> NestedGroups { get; set; } = default!;
        public async Task OnGetAsync()
        {


            /*************** Try Three ****************/
            
            decimal Balance1(int i)
            {
                //var balance = 0m;

                var balance =
                    from b in _context.Movimientos
                    where b.MovMatId == i
                    select b;

                decimal c = 0m;

                foreach (var mov in balance)
                {
                    c += mov.MovQuantity;
                }
                return c;
            }

            var balance =
                from b in _context.Movimientos
                //where b.MovMatId == i
                select b;




            MaterialMovimientosVMs =
                await (from r in _context.Movimientos.Include(i => i.Material).Include(j => j.Almacen)
                       let blnce = _context.Movimientos.Where(w => w.MovMatId == r.MovMatId && w.MovAlmId == r.MovAlmId).Sum(r => r.MovQuantity)
                       let Almblnce = _context.Movimientos.Where(w => w.MovMatId == r.MovMatId).Sum(r => r.MovQuantity)
                       //join s in _context.Movimientos.Include(i => i.Almacen) on r.MaterialId equals s.MovMatId
                       //select g;
                       select new MaterialMovimientosVM
                       {
                           MatBalance = blnce,
                           //MatBalance = 0m,
                           //MatBalance = Balance1(r.MovMatId), // (An expresion tree may not contain a referencto to a local function)
                           //MatBalance = _context.Movimientos.Where(predicate: w => w.MovMatId == r.MovMatId).Sum(),
                           MatId = r.MovMatId,
                           AlmId = r.MovAlmId,
                           MatName = r.Material.MatName,
                           MatUM = r.Material.MatUM,
                           AlmName = r.Almacen.AlmName,
                           AlmQ = Almblnce
                       }).Distinct().ToListAsync();

            //var nestedGroupsQuery =
            //    _context.Movimientos.Include(i => i.Material).Include(v => v.Almacen)
            //    .GroupBy(mov => mov.MovMatId)
            //    .Select(newGroup1 => new
            //    {
            //        newGroup1.Key,
            //        NestedGroup = newGroup1
            //            .GroupBy(mov => mov.MovAlmId)

            //    });


            //NestedGroups = (IEnumerable<IGrouping<int, Movimiento>>)await nestedGroupsQuery.ToListAsync();

            //ViewData["NestedGroup"] = nestedGroupsQuery;

            //return View();


            //foreach (var outerGroup in nestedGroupsQuery)
            //{
            //    Console.WriteLine($"DataClass.Student Level = {outerGroup.Key}");
            //    foreach (var innerGroup in outerGroup.NestedGroup)
            //    {
            //        Console.WriteLine($"\tNames that begin with: {innerGroup.Key}");
            //        foreach (var innerGroupElement in innerGroup)
            //        {
            //            Console.WriteLine($"\t\t{innerGroupElement.MovMatId} {innerGroupElement.MovQuantity}");
            //        }
            //    }
            //}

            //static decimal GetMatQty(int almId, int matId, IList<Movimiento> m)
            //{
            //    var qtys =
            //        (from q in m
            //         where q.MovMatId == matId && q.MovAlmId == almId
            //         select q.MovQuantity).Sum();
            //    return qtys;
            //}

            //var movimientos =
            //    from s in _context.Movimientos
            //        //let v = GetMatQty(s.MovMatId, s.MovAlmId, (IList<Movimiento>)_context.Movimientos)
            //    select new MaterialMovimientosVM
            //    {
            //        AlmId = s.MovAlmId,
            //        AlmName = $"Almacen Name is {s.MovAlmId}",
            //        //AlmQ = new decimal { from c in _context.Movimientos where c.MovMatId == s.MovMatId && c.MovAlmId == s.MovAlmId select c.MovQuantity;).Sum() },
            //        AlmQ = (from a in _context.Movimientos where a.MovMatId == s.MovMatId && a.MovAlmId == s.MovAlmId select a.MovQuantity).Sum(),

            //        MaterialId = s.MovMatId,
            //        MatExistencia = _balance.Balance(s.MovMatId),
            //        MatName = $"Material Name is {s.MovMatId}",
            //        MatUM = "UM"
            //    };

            //var movimientos =
            //    from mov in _context.Movimientos
            //    group mov by mov.MovAlmId into newGroup1
            //    from newGroup2 in
            //    from mov in newGroup1
            //    group mov by mov.MovMatId
            //    group newGroup2 by newGroup1.Key;

            //select new MaterialMovimientosVM
            //{
            //    AlmName = newGroup3.Key.ToString(),
            //    AlmQ = newGroup3.Sel,
            //    MaterialId = newGroup3.Key,
            //    MatExistencia = (decimal)newGroup3.Key,
            //    MatName = (string)newGroup3.Key,
            //    MatUM = (string)newGroup3.Key

            //};
            //var materials = from r in _context.Materiales.Include(m => m.Movimientos)
            //                //join s in _context.Movimientos on r.MaterialId equals s.MovMatId
            //                //group s by s.MovAlmId into g
            //                //select r;

            //select new Material
            //{
            //    MaterialId = r.MaterialId,
            //    MatName = r.MatName,
            //    MatUM = r.MatUM,
            //    Existencia = _balance.Balance(r.MaterialId),
            //    Movimientos = r.Movimientos
            //};

            //Material = await materials.ToListAsync(IList < MaterialMovimientosVM > materialMovimientosVM);

            /************** Try One *****************/
            //var materials = 
            //    from r in _context.Materiales
            //    join s in _context.Movimientos.Include(i => i.Almacen) on r.MaterialId equals s.MovMatId
            //    //select g;
            //    select new MaterialMovimientosVM
            //    {
            //        MatBalance = _balance.Balance(s.MovMatId, s.MovAlmId),
            //        MatId = s.MovMatId,
            //        AlmId = s.MovAlmId,
            //        MatName = r.MatName,
            //        MatUM = r.MatUM,
            //        AlmName = s.Almacen.AlmName,
            //        //AlmQ = _balance.Balance(r.MaterialId, r.AlmacenId),
            //    };

            //MaterialMovimientosVMs = await materials.ToListAsync();


            ///*************** Try Two ****************/
            //MaterialMovimientosVMs =
            //    await (from r in _context.Movimientos.Include(i => i.Material).Include(j => j.Almacen)
            //    //join s in _context.Movimientos.Include(i => i.Almacen) on r.MaterialId equals s.MovMatId
            //    //select g;
            //    select new MaterialMovimientosVM
            //    {
            //        MatBalance = _balance.Balance(_context, r.MovMatId),
            //        MatId = r.MovMatId,
            //        AlmId = r.MovAlmId,
            //        MatName = r.Material.MatName,
            //        MatUM = r.Material.MatUM,
            //        AlmName = r.Almacen.AlmName,
            //        AlmQ = _balance.Balance(_context, r.MovMatId, r.MovAlmId)
            //    }).Distinct().ToListAsync();

            //MaterialMovimientosVMs = await materials.Distinct().ToListAsync();



            //select new MaterialMovimientosVM
            //{
            //   MaterialId = glob


            //};

            //Material = await materials.ToListAsync();
            //Material = await MaterialMovimientosVM.;
            //MaterialMovimientosVMs = await materials.ToListAsync();
            //Movimientos = (IList<Movimiento>)await movimientos.ToListAsync();

            //var movimientos =
            //    from mov in _context.Movimientos
            //    select mov;

            //Movimientos = (IList<Movimiento>)await movimientos.ToListAsync();

            //MaterialMovimientosVMs = (IList<MaterialMovimientosVM>)await movimientos.ToListAsync();
        }
    }
}
