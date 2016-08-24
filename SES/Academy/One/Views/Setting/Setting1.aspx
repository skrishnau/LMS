<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Setting1.aspx.cs" Inherits="One.Views.Setting.Setting1" %>



<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <div style="padding: 5px;">
        <div style="background-color: lightgray; padding-top: 10px; font-size: 1.3em; font-weight: 700; text-align: center;">
            Settings
        <hr />
        </div>
        <div style="margin: 5px; padding: 5px; background-color: aliceblue;">
            <strong>User Settings</strong>
            <hr />
            
            <div style="padding:0 10px;">
                here will be the settings to change the automatic username and password
             (i.e. what fields to include in the username and password)
            </div>
        </div>
        
        <div>
            <strong>User Grouping Settings</strong>
            <hr />
            
            <div style="padding:0 10px;">
                here will be the settings to select the default group in each program-batch
                i.e Group A and Group B for all the strudents in a program batch or say:
                Group-A and Group-B for all Year/Subyear
            </div>
        </div>
        
         <div>
            <strong>Name Settings</strong>
            <hr />
            
            <div style="padding:0 10px;">
                here will be the settings to change the Name of the defaults.
                <br />
                for e.g. Subyear is inappropriate so Give to change Subyear to SEMESTER
                and give to change all other Naming conventions of the system
            </div>
        </div>

    </div>
</asp:Content>
