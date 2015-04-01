using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.Repositories.Library.Common
{
    /// <summary>
    /// Interface Unit Of Work
    /// </summary>
    public interface IUnitOfWork
    {
        void Save();
    }
}
