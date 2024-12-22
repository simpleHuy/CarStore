using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Core.Models;

namespace CarStore.Core.Contracts.Repository;
public interface IShowroomRepository
{
    public Task<Showroom> GetShowroomByUserId(int userId);
}
