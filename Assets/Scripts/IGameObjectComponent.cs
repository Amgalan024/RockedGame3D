using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IGameObjectComponent<T> 
{
    void InitializeComponent(T component);
}
