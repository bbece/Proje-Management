using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Base.General;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Proje_Management.Module.BusinessObjects.Project.MileStone.Tasks
{
    [DefaultClassOptions]
    [DeferredDeletion(false)]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    [Persistent("DatabaseTableTasks")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Tasks : Dugum
    {
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        string task;
        [Size(SizeAttribute.Unlimited)]
        public string Task
        {
            get => task;
            set => SetPropertyValue(nameof(Task), ref task, value);
        }
      

     

        private MileStone projectGroup;
        protected override ITreeNode Parent
        {
            get
            {
                return projectGroup;
            }
        }
        protected override IBindingList Children
        {
            get
            {
                return new BindingList<Tasks>();
            }
        }
        public Tasks(Session session) : base(session) { }
        public Tasks(Session session, string name)
            : base(session)
        {
            this.Name = name;
        }


        
        [Association("ProjectGroup-Projects"),]
        public MileStone ProjectGroup
        {
            get
            {
                return projectGroup;
            }
            set
            {
                SetPropertyValue("ProjectGroup", ref projectGroup, value);
            }
        }
    }
}