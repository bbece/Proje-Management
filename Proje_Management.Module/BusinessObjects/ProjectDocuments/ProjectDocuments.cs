using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using Proje_Management.Module.BusinessObjects.Project;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


public enum ProjectStatus
{
    [ImageName("State_Validation")]
    OnayBekliyor,
    [ImageName("State_Task_Executing")]
    DevamEdiyor,
    [ImageName("State_Task_Completed")]
    Tamamlandi,
    // Diğer durumlar buraya eklenebilir
}

// Parasal Getiri Tipi Enum
public enum FinancialReturnType
{
    Gunluk,
    Aylik,
    Yillik
}

namespace Proje_Management.Module.BusinessObjects.projectDocuments
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    [Persistent("DatabaseTableProjectDocs")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class ProjectDocuments : FileData
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public ProjectDocuments(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        [Association("ProjectDocs-Proje")]
        public Proje Project
        {
            get => GetPropertyValue<Proje>(nameof(Project));
            set => SetPropertyValue(nameof(Project), value);
        }
        private decimal financialReturn;
        public decimal FinancialReturn
        {
            get => financialReturn;
            set => SetPropertyValue(nameof(FinancialReturn), ref financialReturn, value);
        }

        // Parasal Getiri Tipi
        private FinancialReturnType financialReturnType;
        public FinancialReturnType FinancialReturnType
        {
            get => financialReturnType;
            set => SetPropertyValue(nameof(FinancialReturnType), ref financialReturnType, value);
        }

    }
}