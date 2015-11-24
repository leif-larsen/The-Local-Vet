using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLocalVet.Models;

namespace TheLocalVet.Interfaces
{
    public interface IGeolocator
    {
        bool IsGeolocationAvailable { get; }
        bool IsGeolocationEnabled { get; }
        double DesiredAccuracy { get; }

        Task<Position> GetPositionAsync(int timeout);
    }
}
