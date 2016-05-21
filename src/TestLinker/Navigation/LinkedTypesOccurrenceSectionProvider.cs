// Copyright 2016, 2015, 2014 Matthias Koch
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Application.ComponentModel;
using JetBrains.ReSharper.Feature.Services.Tree;
using JetBrains.ReSharper.Feature.Services.Tree.SectionsManagement;
using JetBrains.TreeModels;
using JetBrains.Util;

namespace TestLinker.Navigation
{
  [ShellFeaturePart]
  public class LinkedTypesOccurrenceSectionProvider : OccurenceSectionProvider
  {
    public override bool IsApplicable (OccurenceBrowserDescriptor descriptor)
    {
      return descriptor is LinkedTypesOccurrenceBrowserDescriptor;
    }

    public override ICollection<TreeSection> GetTreeSections (OccurenceBrowserDescriptor descriptor)
    {
      return descriptor.OccurenceSections.Select(
          x =>
          {
            var caption = $"Found {x.Items.Count} linked {NounUtil.ToPluralOrSingular("type", x.Items.Count)}";
            return new TreeSection(x.Model, caption);
          }).ToList();
    }
  }
}