using events.tac.local.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TAC.Sitecore.Abstractions.Interfaces;
using TAC.Sitecore.Abstractions.SitecoreImplementation;

namespace events.tac.local.Business
{
    public class MainNavigationBuilder
    {
        private readonly IRenderingContext _context;

        public MainNavigationBuilder() : this(SitecoreRenderingContext.Create()) { }

        public MainNavigationBuilder(IRenderingContext context)
        {
            _context = context;
        }

        public IEnumerable<NavigationItem> Build()
        {
            return _context?.HomeItem == null || _context?.ContextItem == null ?

                 Enumerable.Empty<NavigationItem>() :

                 _context
                    .ContextItem
                    .GetAncestors()
                    .Where(i => _context.HomeItem.IsAncestorOrSelf(i))
                    .Select(i => new NavigationItem
                    (
                            title: i.DisplayName,
                            url: i.Url,
                            active: false
                    ))
                    .Concat(
                        new[] {
                            new NavigationItem
                            (
                                title   : _context.ContextItem.DisplayName,
                                url     : _context.ContextItem.Url,
                                active  : true
                            )
                        }
                    );
        }

    }
}