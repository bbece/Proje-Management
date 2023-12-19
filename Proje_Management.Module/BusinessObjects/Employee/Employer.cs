using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DevExpress.XtraSpreadsheet.Model;
using Proje_Management.Module.BusinessObjects.Project;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Proje_Management.Module.BusinessObjects.Employee
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    [DefaultProperty("EmployerFullName")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    [Persistent("DatabaseTableEmployers")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Employer : XPObject
    { 
        public Employer(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
        }

        string employerFullName;

        
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [RuleRequiredField(DefaultContexts.Save, CustomMessageTemplate = "Lütfen doldurun")]
        [RuleRegularExpression(DefaultContexts.Save, @"^[a-zA-Z\s]*$", CustomMessageTemplate = "Lütfen sadece harf girin")]
        public string EmployerFullName
        {
            get => employerFullName;
            set
            {
                
                
                    SetPropertyValue(nameof(EmployerFullName), ref employerFullName, value);
                
            }
        }

        [Association("Employer-Team")]
        public ProjectTeam EmployerTeam
        {
            get => GetPropertyValue<ProjectTeam>(nameof(EmployerTeam));
            set => SetPropertyValue(nameof(EmployerTeam), value);
        }
    }
}