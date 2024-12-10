﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Core.Models;
public class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id
    {
        get;
        set;
    }
    public string Name
    {
        get; set;
    }
    public string Email
    {
        get; set;
    }
    public string Telephone
    {
        get; set;
    }
    public string AccountType
    {
        get; set;
    }

    public string PasswordHash
    {
        get; set;
    }
    public string Salt
    {
        get; set;
    }
    public string Username
    {
        get; set;
    }
    public string firstName
    {
        get; set;
    }
    public string lastName
    {
        get; set;
    }

    public ICollection<Schedule> CustommerSchedules { get; set; }
    public ICollection<Schedule> MerchantSchedules { get; set; }
}
