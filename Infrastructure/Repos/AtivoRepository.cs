﻿using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repos;

public class AtivoRepository : IAtivoRepository
{
	private readonly AppDbContext _ctx;

	public AtivoRepository(AppDbContext ctx)
	{
		_ctx = ctx;
	}

	public async ValueTask Create(Ativo ativo)
	{
		await _ctx.Ativo.AddAsync(ativo);
		await _ctx.SaveChangesAsync();
	}

	public async ValueTask<IEnumerable<Ativo>> GetAll()
	{
		return await _ctx.Ativo
			.AsNoTracking()
			.ToListAsync();
	}

	public async ValueTask<Ativo> GetById(Guid id)
	{
		return await _ctx.Ativo
			.AsNoTracking()
			.FirstOrDefaultAsync(x => x.Id.Equals(id));
	}

	public async ValueTask<Ativo> UpdateAsync(Ativo ativo)
	{
		_ctx.Ativo.Update(ativo);
		await _ctx.SaveChangesAsync();
		return ativo;
	}

	public async ValueTask<Ativo> RemoveAsync(Ativo ativo)
	{
		_ctx.Ativo.Remove(ativo);
		await _ctx.SaveChangesAsync();
		return ativo;
	}
}