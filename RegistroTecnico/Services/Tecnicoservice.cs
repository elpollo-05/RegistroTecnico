﻿using Microsoft.EntityFrameworkCore;
using RegistroTecnico.DAL;
using RegistroTecnico.Models;
using System.Linq.Expressions;

namespace RegistroTecnico.Services
{
    public class Tecnicoservice
    {
        private readonly Contexto _Contexto;
        public Tecnicoservice(Contexto Contexto)
        {
            _Contexto = Contexto;
        }
        public async Task<bool> Existe(String nombre)
        {
            return await _Contexto.Tecnicos
              .AnyAsync(T => T.Nombre == nombre);
        }

        public async Task<bool> Insertar(Tecnicos tecnicos)
        {
            await _Contexto.Tecnicos.AddAsync(tecnicos);
            return await _Contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Modificar(Tecnicos tecnicos)
        {
            _Contexto.Update(tecnicos);
            return await _Contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Tecnicos tecnicos)
        {
            //Busca la prioridad, si no existe la inserta, si existe la modifica
            if (!await Existe(tecnicos.Nombre))
                return await Insertar(tecnicos);
            else
                return await Modificar(tecnicos);
        }
        public async Task<bool> ELiminar(int tecniCold)
        {
            var tecnicos = await _Contexto.Tecnicos.
              Where(P => P.TecniCold == tecniCold).ExecuteDeleteAsync();
            return tecnicos > 0;
        }
        public async Task<Tecnicos?> Buscar(int tecniCold)
        {
            return await _Contexto.Tecnicos.
              AsNoTracking()
             .FirstOrDefaultAsync(T => T.TecniCold == tecniCold);

        }

        public async Task<List<Tecnicos>> Listar(Expression<Func<Tecnicos, bool>> criterio)
        {
            return await _Contexto.Tecnicos.
              AsNoTracking()
              .Where(criterio)
              .ToListAsync();

        }




    }
} 