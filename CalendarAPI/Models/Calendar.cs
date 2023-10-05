﻿using Shared.Entities;

namespace CalendarAPI.Models;

public class Calendar: IEntityBase
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public Guid UserId { get; set; }
    // public User User { get; set; }
}