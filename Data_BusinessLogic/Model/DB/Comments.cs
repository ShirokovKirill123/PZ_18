using Data_BusinessLogic.DB.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_BusinessLogic.DB
{
    public class Comments : IComments, INotifyPropertyChanged
    {
        public int Id => throw new NotImplementedException();

        public string Message { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int RequestId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int MasterId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
