﻿using ContainRs.Application.Repositories;
using ContainRs.Domain.Models;

namespace ContainRs.Application.UseCases;

public class ConsultarClientes
{
    private readonly IClienteRepository repository;
    public ConsultarClientes(UnidadeFederativa? estado, IClienteRepository repository)
    {
        Estado = estado;
        this.repository = repository;
    }

    public UnidadeFederativa? Estado { get; }

    public Task<IEnumerable<Cliente>> ExecutarAsync()
    {

    }
}
