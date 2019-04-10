using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using TUM.CMS.VplControl.Utilities;
using VPL.UI.Model;
using DevExpress.Utils.Design;
using DevExpress.Xpf.Core;
using GalaSoft.MvvmLight.CommandWpf;

namespace VPL.UI.ViewModel
{
    public class ucToolboxViewModel
    {

        #region Constructors
        public ucToolboxViewModel()
        {
            BindingCommands();
            GetNodeList();
        }
        #endregion

        #region Public Properties
        public List<ToolboxItem> typeList { get; set; }

        #region Commands

        public ICommand RefreshToolboxCommand { get; set; }
        #endregion

        #endregion


        #region Private Properties

        private void BindingCommands()
        {
            RefreshToolboxCommand = new RelayCommand(RefreshToolboxExecute);
        }

        private void RefreshToolboxExecute()
        {
            DXMessageBox.Show("Refreshed Toolbox");
        }

        #endregion

        #region Private Methods
        private void GetNodeList()
        {
            AppDomain currentAppDomain = AppDomain.CurrentDomain;
            typeList = new List<ToolboxItem>();
            //var tumcmsAssembly2 = currentAppDomain.GetAssemblies().ToList();
            var tumcmsAssembly = currentAppDomain.GetAssemblies().FirstOrDefault(x => x.FullName == "TUM.CMS.VplControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");

            var tempTypeList = new List<Type>();
            tempTypeList.AddRange(Utilities.GetTypesInNamespace(tumcmsAssembly, "TUM.CMS.VplControl.Nodes").Where(type => !type.IsAbstract && !type.Name.Contains("<>")).ToList());

            var test = DXImageHelper.GetImageSource("Add", ImageSize.Size16x16, ImageType.Colored);
            typeList = tempTypeList.OrderBy(x => x.Name).Select(x => new ToolboxItem()
            {
                Name = x.Name,
                Image = test,
                Type = x
            }).ToList();
        }

        #endregion

    }
}
