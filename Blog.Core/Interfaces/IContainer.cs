using Blog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Interfaces
{
    public interface IContainer : IDisposable
    {
        IPostRepository PostRepository { get; }

     

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
