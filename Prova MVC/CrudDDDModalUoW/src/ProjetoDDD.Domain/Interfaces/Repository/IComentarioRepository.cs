﻿using ProjetoDDD.Domain.Entities;
using System;

namespace ProjetoDDD.Domain.Interfaces.Repository
{
    public interface IComentarioRepository : IRepository<Comentario>, IDisposable
    {
    }
}
