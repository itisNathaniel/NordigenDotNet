﻿using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

using VMelnalksnis.NordigenDotNet.Serialization;

namespace VMelnalksnis.NordigenDotNet.Institutions;

/// <inheritdoc />
public sealed class InstitutionClient : IInstitutionClient
{
	private readonly HttpClient _httpClient;
	private readonly NordigenSerializationContext _context;

	/// <summary>Initializes a new instance of the <see cref="InstitutionClient"/> class.</summary>
	/// <param name="httpClient">Http client configured for making requests to the Nordigen API.</param>
	/// <param name="serializerOptions">Nordigen specific instance of <see cref="JsonSerializerOptions"/>.</param>
	public InstitutionClient(HttpClient httpClient, NordigenJsonSerializerOptions serializerOptions)
	{
		_httpClient = httpClient;
		_context = serializerOptions.Context;
	}

	/// <inheritdoc />
	public Task<List<Institution>> GetByCountry(string countryCode, CancellationToken cancellationToken = default)
	{
		return _httpClient.Get(
			Routes.Institutions.CountryUri(countryCode),
			_context.ListInstitution,
			cancellationToken)!;
	}

	/// <inheritdoc />
	public Task<Institution> Get(string id, CancellationToken cancellationToken = default)
	{
		return _httpClient.Get(
			Routes.Institutions.IdUri(id),
			_context.Institution,
			cancellationToken)!;
	}
}
