<%@ Page Title="" Language="C#" MasterPageFile="~/HotelShop.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:LoginView ID="LoginView1" runat="server">
    <LoggedInTemplate>
      Вече сте регистриран.
    </LoggedInTemplate>
  </asp:LoginView>
  <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" BackColor="#F7F6F3" 
    BorderColor="#E6E2D8" BorderStyle="Solid" BorderWidth="1px" 
    CancelDestinationPageUrl="~/" ContinueDestinationPageUrl="CustomerDetails.aspx" 
    CreateUserButtonText="Регистрация" Font-Names="Verdana" Font-Size="0.8em" 
    oncreateduser="CreateUserWizard1_CreatedUser" CancelButtonText="Прекрати" CompleteSuccessText="Акаунтът Ви беше създаден успешно" ContinueButtonText="Продължи" DuplicateEmailErrorMessage="Пощата, която сте въвели вече се използва. Моля въведете друга поща." DuplicateUserNameErrorMessage="Моля въвадете друго потребителско име." FinishCompleteButtonText="Край" FinishPreviousButtonText="Предишен" InvalidAnswerErrorMessage="Моля въведете друг таен отговор." InvalidEmailErrorMessage="моля въведете валидна електронна поща." InvalidPasswordErrorMessage="Дължина на паролата минимум: {0}. Без латински букви и арабски цифри: {1}." InvalidQuestionErrorMessage="Моля въведете друг таен въпрос." StartNextButtonText="Следващ" StepNextButtonText="Следващ" StepPreviousButtonText="Предишен" UnknownErrorMessage="Акаунтът Ви не беше създаден. Моля опитайте пак.">
    <SideBarStyle BackColor="#5D7B9D" BorderWidth="0px" Font-Size="0.9em" 
      VerticalAlign="Top" />
    <SideBarButtonStyle BorderWidth="0px" Font-Names="Verdana" ForeColor="White" />
    <ContinueButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" 
      BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
      ForeColor="#284775" />
    <NavigationButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" 
      BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
      ForeColor="#284775" />
    <HeaderStyle BackColor="#5D7B9D" BorderStyle="Solid" Font-Bold="True" 
      Font-Size="0.9em" ForeColor="White" HorizontalAlign="Center" />
    <CreateUserButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" 
      BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
      ForeColor="#284775" />
    <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <StepStyle BorderWidth="0px" />
    <WizardSteps>
      <asp:CreateUserWizardStep runat="server" >
          <ContentTemplate>
              <table style="font-family:Verdana;font-size:100%;">
                  <tr>
                      <td align="center" colspan="2" style="color:White;background-color:#5D7B9D;font-weight:bold;">Попълнете за новия си акаунт</td>
                  </tr>
                  <tr>
                      <td align="right">
                          <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Потребителско име:</asp:Label>
                      </td>
                      <td>
                          <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="Потребителското име е задължително." ToolTip="Потребителското име е задължително." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                      </td>
                  </tr>
                  <tr>
                      <td align="right">
                          <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Парола:</asp:Label>
                      </td>
                      <td>
                          <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Паролата е задължителна." ToolTip="Паролата е задължителна." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                      </td>
                  </tr>
                  <tr>
                      <td align="right">
                          <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Потвърдете паролата:</asp:Label>
                      </td>
                      <td>
                          <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword" ErrorMessage="Потвърждаването на паролата е задължително." ToolTip="Потвърждаването на паролата е задължително." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                      </td>
                  </tr>
                  <tr>
                      <td align="right">
                          <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">Поща:</asp:Label>
                      </td>
                      <td>
                          <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" ErrorMessage="Пощата е задължителна." ToolTip="Пощата е задължителна." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                      </td>
                  </tr>
                  <tr>
                      <td align="right">
                          <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">Таен въпрос:</asp:Label>
                      </td>
                      <td>
                          <asp:TextBox ID="Question" runat="server"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question" ErrorMessage="Тайният въпрос е задължителен." ToolTip="Тайният въпрос е задължителен." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                      </td>
                  </tr>
                  <tr>
                      <td align="right">
                          <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Таен отговор:</asp:Label>
                      </td>
                      <td>
                          <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer" ErrorMessage="Тайният отговор е задължителен." ToolTip="Тайният отговор е задължителен." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                      </td>
                  </tr>
                  <tr>
                      <td align="center" colspan="2">
                          <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="Паролите трябва да съвпадат." ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                      </td>
                  </tr>
                  <tr>
                      <td align="center" colspan="2" style="color:Red;">
                          <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                      </td>
                  </tr>
              </table>
          </ContentTemplate>
        </asp:CreateUserWizardStep>
      <asp:CompleteWizardStep runat="server" />
    </WizardSteps>
  </asp:CreateUserWizard>
</asp:Content>

