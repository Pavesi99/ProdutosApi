﻿using Domain.Enum;
using Domain.Interfaces.NomeDaBase;
using Infra.CrossCutting.Dto;
using Infra.Data.Config;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using Infra.Data.Context;
using System.Text;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories.ItlSys
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository( ProdutoContext context) : base(context)
        {
        }

        public Categoria Cadastrar(Categoria categoria)
        {
            var categoriaDb = this.Buscar(categoria.Codigo);
            if (categoriaDb == null)
            {
                this.Add(categoria);
            }else
            {
                categoriaDb.AtualizarDados(categoriaDb.Codigo, categoria.Nome);
                this.Update(categoriaDb);
            }
            return categoria;
        }

        public Categoria Buscar(int categoriaId)
        {
            return  _dbSet.FirstOrDefaultAsync(x => x.Codigo == categoriaId).Result;
        }

        public Categoria Deletar(int categoriaId)
        {
            Categoria categoria = this.Buscar(categoriaId);
            this.Remove(categoria);
            return categoria;
        }
    }
}