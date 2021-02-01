using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using Blueprint.Plugins;

namespace Blueprint
{
    public class MenuExtensionUsagesAttribute : Attribute
	{
		public MenuExtensionUsagesAttribute(string section, string name)
		{
			this.section = section;
			this.name = name;
		}
		public string name;
		public string section;
	}

	public class MenuExtender
	{
		private List<ToolStripMenuItem> actionMenuList = new List<ToolStripMenuItem>();
		private ToolStripMenuItem parentMenuItem;
		private PluginMenuProxy executeProxy;
        private Type baseClassInterface;

		public MenuExtender(ToolStripMenuItem baseMenuItem, PluginMenuProxy proxy, Type baseClass)
		{
			executeProxy = proxy;
			parentMenuItem = baseMenuItem;
            baseClassInterface = baseClass;
        }

		public void LoadOperationsFromAssembly(Assembly asm)
		{
			foreach (Type type in asm.GetTypes())
			{
				if (baseClassInterface.IsAssignableFrom(type) && typeof(PluginMenuExtension).IsAssignableFrom(type))
				{
					MenuExtensionUsagesAttribute attrib = type.GetCustomAttribute(typeof(MenuExtensionUsagesAttribute), false) as MenuExtensionUsagesAttribute;
					if (attrib != null)
					{
                        PluginMenuExtension opInstance = Activator.CreateInstance(type) as PluginMenuExtension;
                        if (opInstance != null)
                        {
                            AddctionToMenu(opInstance, attrib);
                        }
					}
				}
			}
		}

		private void AddctionToMenu(PluginMenuExtension pluginExt, MenuExtensionUsagesAttribute usage)
		{
			ToolStripMenuItem sectionItem = GetSection(usage.section);
			if (sectionItem != null)
			{
				sectionItem.DropDownItems.Add(usage.name, null, (x, y) => executeProxy.Execute(pluginExt));
			}
		}

		private ToolStripMenuItem GetSection(string section)
		{
			ToolStripMenuItem sectionItem = actionMenuList.Find((x) => x.Text.ToLower() == section.ToLower());
			if (sectionItem == null)
			{
				sectionItem = new ToolStripMenuItem(section);
				actionMenuList.Add(sectionItem);
				parentMenuItem.DropDownItems.Add(sectionItem);
			}
			return sectionItem;
		}
	}
}

