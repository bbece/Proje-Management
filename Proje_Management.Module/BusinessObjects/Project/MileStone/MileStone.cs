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

namespace Proje_Management.Module.BusinessObjects.Project.MileStone
{
    [DefaultClassOptions]
    [DeferredDeletion(false)]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    [Persistent("DatabaseTableMileStones")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class MileStone : Dugum
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
     
        protected override ITreeNode Parent
        {
            get
            {
                return null;
            }
        }
        protected override IBindingList Children
        {
            get
            {
                return Tasks;
            }
        }
        public MileStone(Session session) : base(session) { }
        public MileStone(Session session, string name)
            : base(session)
        {
            this.Name = name;
        }
        

        [Association("ProjectGroup-Projects"), DevExpress.Xpo.Aggregated]
        public XPCollection<Tasks.Tasks> Tasks
        {
            get
            {
                return GetCollection<Tasks.Tasks>("Tasks");
            }
        }
    }
}