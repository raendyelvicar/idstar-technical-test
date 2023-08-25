﻿namespace TransactionsService.Entities;
public class BaseEntity
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public DateTime DeletedAt { get; set; }= DateTime.UtcNow;
}
