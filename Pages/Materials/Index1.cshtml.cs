﻿using System;
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
    public class Index1Model : PageModel
    {
        private readonly AlmacenesContext _context;
        private readonly IMaterialBalance _balance;

        public Index1Model(AlmacenesContext context, IMaterialBalance balance)
        {
            _context = context;
            _balance = balance;
        }

        public IList<Material> Material { get;set; } = default!;
        [BindProperty (SupportsGet = true)]
        public IList<Movimiento> Movimientos { get;set; } = new List<Movimiento> ();
        public IList<MaterialMovimientosVM> MaterialMovimientosVMs { get;set; } = default!;
        public async Task OnGetAsync()
        {
            var Movimientos =
                (from mov in _context.Movimientos.Include(i => i.Almacen).Include(j => j.Material)
                select new Movimiento
                {
                    MovimientoId = mov.MovimientoId,
                    MovAlmId = mov.MovAlmId,
                    MovDate = mov.MovDate,
                    MovMatId = mov.MovMatId,
                    MovQuantity = 1, /*_balance.Balance(_context, mov.MovMatId),*/
                    MovUnitPrice = mov.MovUnitPrice
                });

            await Movimientos.ToListAsync();
            //var movimientos =
            //    from mov in _context.Movimientos
            //    group mov by mov.MovAlmId into newGroup1
            //    from newGroup2 in
            //    from mov in newGroup1
            //    group mov by mov.MovMatId
            //    group newGroup2 by newGroup1.Key;

            /*************** Try One **************/
            //var materials = from r in _context.Materiales.Include(m => m.Movimientos)
            //                    //join s in _context.Movimientos on r.MaterialId equals s.MovMatId
            //                    //group s by s.MovAlmId into g
            //                    //select r;

            //                select new Material
            //                {
            //                    MaterialId = r.MaterialId,
            //                    MatName = r.MatName,
            //                    MatUM = r.MatUM,
            //                    Existencia = _balance.Balance(r.MaterialId),
            //                    Movimientos = r.Movimientos
            //                };

            //Material = await materials.ToListAsync();


            //Material = await materials.ToListAsync(IList<MaterialMovimientosVM> materialMovimientosVM);

            //var materials = from r in _context.Materiales
            //                join s in _context.Movimientos.Include(i => i.Almacen) on r.MaterialId equals s.MovMatId
            //                //select g;
            //                select new MaterialMovimientosVM
            //                {
            //                    MatExistencia = _balance.Balance(r.MaterialId),
            //                    MaterialId = r.MaterialId,
            //                    MatName = r.MatName,
            //                    MatUM =r.MatUM,
            //                    AlmName = s.Almacen.AlmName,    
            //                    AlmQ = s.MovQuantity



            //};



            //select new MaterialMovimientosVM
            //{
            //   MaterialId = glob


            //};

            //Material = await MaterialMovimientosVM.;
            //MaterialMovimientosVMs = await materials.ToListAsync();
            //Movimientos = (IList<Movimiento>)await movimientos.ToListAsync();

            /*************** Try Two **************/
            //var movimientos =
            //    from mov in _context.Movimientos.Include(i => i.Almacen).Include(i => i.Material)
            //    select mov;

            //Movimientos = await movimientos.ToListAsync();

            /*************** Try Three **************/

            //Movimientos = await movimientos.ToListAsync();



            //var movimientos1 =
            //    from mov in _context.Movimientos

            //    select mov;



        }
    }
}
