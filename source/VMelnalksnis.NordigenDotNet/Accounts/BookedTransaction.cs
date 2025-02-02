﻿// Copyright 2022 Valters Melnalksnis
// Licensed under the Apache License 2.0.
// See LICENSE file in the project root for full license information.

using NodaTime;

using VMelnalksnis.NordigenDotNet.Institutions;

namespace VMelnalksnis.NordigenDotNet.Accounts;

/// <summary>A transaction that has been booked - posted to an account on the account servicer's books.</summary>
public record BookedTransaction : Transaction
{
	/// <summary>Gets or sets a unique transaction id created by the <see cref="Institution"/>.</summary>
	public string TransactionId { get; set; } = null!;

	/// <summary>Gets or sets the name of the counterparty that sends <see cref="Transaction.TransactionAmount"/> during the transaction.</summary>
	public string? DebtorName { get; set; }

	/// <summary>Gets or sets the account of the counterparty that sends <see cref="Transaction.TransactionAmount"/> during the transaction.</summary>
	public TransactionAccount? DebtorAccount { get; set; }

	/// <summary>Gets or sets the account of the counterparty that receives <see cref="Transaction.TransactionAmount"/> during the transaction.</summary>
	public TransactionAccount? CreditorAccount { get; set; }

	/// <summary>Gets or sets the ISO 20022 bank transaction code.</summary>
	/// <example>Some example values:
	/// <code>
	/// PMNT-ICDT-STDO
	/// PMNT-IRCT-STDO
	/// </code></example>
	public string? BankTransactionCode { get; set; }

	/// <summary>Gets or sets additional structured information about the transaction from the institution.</summary>
	/// <example>
	/// <code>
	/// PURCHASE
	/// INWARD TRANSFER
	/// </code></example>
	public string? AdditionalInformation { get; set; }
}
