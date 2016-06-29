using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values;

namespace One.Views.AcademicPlacement.StudentClass
{
    public partial class BatchSelectUc : System.Web.UI.UserControl
    {

        public event EventHandler<RunningClassEventArgs> SaveClicked;
        public event EventHandler<MessageEventArgs> CloseClicked;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Properties

        public int AcademicYearId { get; set; }
        public int ProgramId { get; set; }
        public int YearId { get; set; }
        public int SubYearId { get; set; }
        #endregion


        public void LoadStudentGroup(Values.RunningClassEventArgs e, int academicYearId
            , int programId, int yearId, int? sessionId = 0, int? subYearId = 0
            ,int programBatchId=0)
        {
            using (var batchhelper = new DbHelper.Batch())
            using (var acaPlcelper = new DbHelper.AcademicPlacement())
            using (var acahelper = new DbHelper.AcademicYear())
            using (var stdHelper = new DbHelper.Student())
            {
                if (programBatchId > 0)
                {
                    var pb = batchhelper.GetProgramBatch(programBatchId);
                    if (pb != null)
                    {
                        lblProgramBatch.Text = pb.NameFromBatch;
                        hidProgramBatchId.Value = pb.Id.ToString();
                    }
                }
                else
                {
                    lblProgramBatch.Text = "";
                    hidProgramBatchId.Value = "0";
                }

                if (e.Type == "year")
                {
                    Academic.DbEntities.AcademicYear prevAcaYear = acahelper.GetPreviousAcademicYear(academicYearId); ;
                    //get student studying in one year less in previous academic year
                    if (prevAcaYear != null)
                    {
                        var programBatch = acaPlcelper.GetProgramBatchInAcademicYear(prevAcaYear.Id, e.YearId);
                        if (programBatch != null)
                        {
                            lstEarlier.DataValueField = "Id";
                            lstEarlier.DataTextField = "Name";
                            lstEarlier.Items.Add(new ListItem(programBatch.NameFromBatch, programBatch.Id.ToString()));
                        }
                        lstOthergroups.DataValueField = "Id";
                        lstOthergroups.DataTextField = "NameFromBatch";
                        lstOthergroups.DataSource = acaPlcelper.GetProgramBatchListStudying(prevAcaYear.Id);
                        lstNewGroups.DataBind();



                    }
                }
                else if (e.Type == "subyear")
                {
                    Academic.DbEntities.Session prevSession = acahelper.GetPreviousSession(academicYearId, sessionId ?? 0); ;
                    //get student studying in one subyear less in previous session
                    if (prevSession != null)
                    {
                        var acaYear = prevSession.AcademicYear;

                        lstOthergroups.DataValueField = "Id";
                        lstOthergroups.DataTextField = "NameFromBatch";
                        lstOthergroups.DataSource = acaPlcelper.GetProgramBatchListStudying(prevSession.AcademicYearId, prevSession.Id);
                        lstNewGroups.DataBind();

                        //stdOtherGrps = acaPlcelper.GetProgramBatchListStudying(prevSession.AcademicYearId, prevSession.Id);
                        //lstOthergroups.DataSource = stdOtherGrps;
                        //lstOthergroups.DataValueField = "Id";
                        //lstOthergroups.DataTextField = "Name";

                        var programBatch = acaPlcelper.GetProgramBatchInAcademicYear(prevSession.AcademicYearId
                            , e.YearId, sessionId: prevSession.Id, subYearId: e.SubYearId);
                        if (programBatch != null)
                        {
                            lstEarlier.DataValueField = "Id";
                            lstEarlier.DataTextField = "NameFromBatch";
                            lstEarlier.Items.Add(new ListItem(programBatch.NameFromBatch, programBatch.Id.ToString()));
                        }


                        //stdGrpInYr = acaPlcelper.GetStudentGroupStudyingInYearOrSubYearInAcademicYear(acaYear.Id
                        //, e.YearId, sessionId: prevSession.Id, subYearId: e.SubYearId);
                        //lstEarlier.DataSource = stdGrpInYr;
                        //lstEarlier.DataValueField = "Id";
                        //lstEarlier.DataTextField = "Name";
                    }
                }

                lstNewGroups.DataValueField = "Id";
                lstNewGroups.DataTextField = "NameFromBatch";
                var newbatches = batchhelper.GetNewProgramBatchList(e.ProgramId);
                //foreach (var programBatch in newbatches)
                //{
                //    lstNewGroups.Items.Add(new ListItem(programBatch.NameFromBatch,programBatch.Id.ToString()));
                //}
                lstNewGroups.DataSource = newbatches;
                lstNewGroups.DataBind();
                //stdNewGrps = stdHelper.GetNewStudentGroups(Values.Session.GetSchool(Session));
                //lstNewGroups.DataSource = stdNewGrps;
                //lstNewGroups.DataValueField = "Id";
                //lstNewGroups.DataTextField = "Name";

            }
        }



        protected void btnClose_Click(object sender, ImageClickEventArgs e)
        {
            if (CloseClicked != null)
            {
                CloseClicked(this, StaticValues.CancelClickedMessageEventArgs);
            }
        }

        protected void lstNewGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblProgramBatch.Text = lstNewGroups.SelectedItem.Text;
            hidProgramBatchId.Value = lstNewGroups.SelectedItem.Value;
            lstOthergroups.ClearSelection();
            lstEarlier.ClearSelection();
        }

        protected void lstEarlier_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblProgramBatch.Text = lstEarlier.SelectedItem.Text;
            hidProgramBatchId.Value = lstEarlier.SelectedItem.Value;

            lstOthergroups.ClearSelection();
            lstNewGroups.ClearSelection();
        }

        protected void lstOthergroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblProgramBatch.Text = lstOthergroups.SelectedItem.Text;
            hidProgramBatchId.Value = lstOthergroups.SelectedItem.Value;

            lstNewGroups.ClearSelection();
            lstEarlier.ClearSelection();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (SaveClicked != null)
            {
                var args = new RunningClassEventArgs()
                    {
                        SubYearId = SubYearId
                        ,
                        YearId = YearId
                            //,RunningClassId = r
                        ,
                        ProgramId = ProgramId
                        //,Type = 
                        ,ProgramBatchId = Convert.ToInt32(hidProgramBatchId.Value)
                        ,ProgramBatchName = lblProgramBatch.Text
                    };
                SaveClicked(this, args);
            }

        }

    }
}