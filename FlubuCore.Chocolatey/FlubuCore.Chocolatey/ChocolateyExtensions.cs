using System;
using System.Collections.Generic;
using System.Text;
using FlubuCore.Context.FluentInterface.Interfaces;

// ReSharper disable once CheckNamespace
namespace FlubuCore.Context.FluentInterface
{
    public static class ChocolateyExtensions
    {
        public static Chocolatey.Chocolatey Chocolatey(this ITaskFluentInterface flubu)
        {
            return new Chocolatey.Chocolatey();
        }
    }
}
