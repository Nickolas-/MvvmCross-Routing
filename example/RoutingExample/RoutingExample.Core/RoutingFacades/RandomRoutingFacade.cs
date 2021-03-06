﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Charri.MvvmCross.Plugins.Routing;
using MvvmCross.Core.ViewModels;
using RoutingExample.Core.RoutingFacades;
using RoutingExample.Core.ViewModels;

[assembly: MvxRouting(typeof(RandomRoutingFacade), @"mvx://random")]

namespace RoutingExample.Core.RoutingFacades
{
    public class RandomRoutingFacade
        : IMvxRoutingFacade
    {
        public Task<MvxViewModelRequest> BuildViewModelRequest(string url, IDictionary<string, string> currentParameters, MvxRequestedBy requestedBy)
        {
            // you can also use the values captured by the regex in currentPrameters

            var viewModelType = (new Random().Next() % 2 == 0) ? typeof(TestAViewModel) : typeof(TestBViewModel);

            return Task.FromResult(new MvxViewModelRequest(viewModelType, new MvxBundle(), null, requestedBy));
        }
    }
}
