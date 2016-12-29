<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SiteMenu.ascx.cs" Inherits="Dairy.UserControl.SiteMenu" %>
<aside class="main-sidebar">
        <!-- sidebar: style can be found in sidebar.less -->
        <section class="sidebar">
          <!-- Sidebar user panel -->
          <div class="user-panel">
            <div class="pull-left image">
              <img src="/Theme/img/logo.png" class="img-circle" alt="User Image">
            </div>
           <%-- <div class="pull-left info">
              <p>  </p>
              <a href="#"/> 
            </div>--%>
          </div>
          

            
<asp:Panel runat="server" ID="pnlAddminitration" Visible="false">

         <ul class="sidebar-menu">
          
    
         
             <li class="treeview ">
              <a href="#">
                <i class="fa fa-edit fax2"></i>
                <span> Administration</span>
                <i class="fa fa-angle-left pull-right"></i>
              </a>
              <ul class="treeview-menu">
                <li><a href="/Tabs/Administration/CreateUser.aspx"><i class="fa fa-user-plus"></i> Create User</a></li>
                  <li><a href="/Tabs/Administration/UserLog.aspx"><i class="fa fa-user-plus"></i> User Log</a></li>
                  <li><a href="/Tabs/Administration/BoothLog.aspx"><i class="fa fa-user"></i> Booth Log</a></li>
                  <li><a href="/Tabs/Administration/EmployeeInfo.aspx"><i class="fa fa-circle-o"></i> Employee Information</a></li>                 
                   <li><a href="/Tabs/Administration/AddRoute.aspx"><i class="fa fa-circle-o"></i> Route Information</a></li>
                  <li><a href="/Tabs/Administration/AddAgent.aspx"><i class="fa fa-circle-o"></i> Agent Information</a></li>
                  <li><a href="/Tabs/Administration/AddLocation.aspx"><i class="fa fa-circle-o"></i> Location Information</a></li>
                 <li><a href="/Tabs/Administration/Shift.aspx"><i class="fa fa-circle-o"></i> Shifts</a></li> 
                  <li><a href="/Tabs/Administration/AddBank.aspx"><i class="fa fa-circle-o"></i> Bank Information</a></li>
                  <li><a href="/Tabs/Administration/Department.aspx"><i class="fa fa-circle-o"></i> Department Information</a></li>
                   <li><a href="/Tabs/Administration/AddDesignation.aspx"><i class="fa fa-circle-o"></i> Designation Information</a></li>
                  <li><a href="/Tabs/Administration/UnitMaster.aspx"><i class="fa fa-circle-o"></i> Unit Information</a></li>
                  <li><a href="/Tabs/Administration/IncentiveSetup.aspx"><i class="fa fa-circle-o"></i> Incentive Rate Setup </a></li>
                      <li><a href="/Tabs/Administration/DamageRateSetup.aspx"><i class="fa fa-circle-o"></i>Damage Rate Setup  </a></li>
                <li><a href="/Tabs/Procurement/RawMilkTariff.aspx"><i class="fa fa-circle-o"></i>RawMilkTarrif</a></li>
               <li><a href="/Tabs/Procurement/VehicleTariff.aspx"><i class="fa fa-circle-o"></i> Vehicle Tariff Info</a></li>
                   <li><a href="/Tabs/Procurement/ConsolidatePaymentSummary.aspx"><i class="fa fa-circle-o"></i>Consolidate Payment Summary</a></li>
             
                    <li><a href="/Tabs/Procurement/AddMilkCollectionCenter.aspx"><i class="fa fa-circle-o"></i>Milk Collection Center Profile</a></li>
   <li><a href="/Tabs/Procurement/IncentiveTarrif.aspx"><i class="fa fa-circle-o"></i>Procurement Incentive Tarrif</a></li>
              </ul>
            </li>
              <li class="treeview">
              <a href="#">
                <i class="fa fa-gg fax2"> </i>
                <span> Product Information</span>
                <i class="fa fa-angle-left pull-right"></i>
              </a>
              <ul class="treeview-menu">
                   
                      <li><a href="/Tabs/Administration/AddBrand.aspx"><i class="fa fa-circle-o"></i> Add Brand</a></li>
                      <li><a href="/Tabs/Administration/AddTypeInfo.aspx"><i class="fa fa-circle-o"></i> Add Product Type</a></li>
                       <li><a href="/Tabs/Administration/addCommodity.aspx"><i class="fa fa-circle-o"></i> Add Commodity</a></li>
              </ul>
            </li>
              
      <li class="treeview">
              <a href="#">
                <i class="fa fa-check-square-o fax2"></i>
                <span>Rate Slab Information</span>
                <i class="fa fa-angle-left pull-right"></i>
              </a>
              <ul class="treeview-menu">
                  <li><a href="/Tabs/Administration/Addslab.aspx"><i class="fa fa-circle-o"></i> Slab Maintenance </a></li>
                  <li><a href="/Tabs/Administration/AddProduct.aspx"><i class="fa fa-circle-o"></i> Rate Maintenance</a></li>    
                  <li><a href="/Tabs/Administration/BindSlab.aspx"><i class="fa fa-circle-o"></i> Agent Slab Maintenance</a></li>
              </ul>
            </li>
              
            
            <li class="treeview">
              <a href="#">
                <i class="fa fa-cart-plus fax2"></i>
                <span>Order Placing</span>
                <i class="fa fa-angle-left pull-right"></i>
              </a>
              <ul class="treeview-menu">

                   <li><a href="/Tabs/Administration/PlaceOrderRoutewise.aspx"><i class="fa fa-circle-o"></i>  Routewise Agency Order</a></li>
                  <li><a href="/Tabs/Administration/PlaceOrderEmpRoutewise.aspx"><i class="fa fa-circle-o"></i>  Routewise Employee Order</a></li>
                  <li><a href="/Tabs/Administration/PlaceOrder.aspx"><i class="fa fa-circle-o"></i>  Daily Agency Order</a></li>
                  <li><a href="/Tabs/Administration/EditOrder.aspx"><i class="fa fa-circle-o"></i>Edit Order</a></li>
                  <li><a href="/Tabs/Administration/OrderQuantity.aspx"><i class="fa fa-circle-o"></i>Order Summary</a></li>
                  <li><a href="/Tabs/Administration/CancelOrderM.aspx"><i class="fa fa-circle-o"></i>Cancel Bill</a></li>
                  <li><a href="/Tabs/Administration/BillSequence.aspx"><i class="fa fa-circle-o"></i> Bill Sequence</a></li>
                  <li><a href="/Tabs/Administration/GenrateBillThermal.aspx"><i class="fa fa-circle-o"></i>Generate Thermal Bill</a></li>
                  <li><a href="/Tabs/Administration/GenrateBill.aspx"><i class="fa fa-circle-o"></i> Generate Bill</a></li> 
                  <li><a href="/Tabs/Administration/DuplicateBillForAgent.aspx"><i class="fa fa-circle-o"></i>Orderwise Sales Bill</a></li>
                 <li><a href="/Tabs/Reports/ItemwiseOrderSummary.aspx"><i class="fa fa-circle-o"></i>Item Wise Order Summary</a></li> 
                <li><a href="/Tabs/Reports/RatewiseOrderSummary.aspx"><i class="fa fa-circle-o"></i>Rate Wise Order Summary</a></li> 
              </ul>
            </li>

             <li class="treeview">
              <a href="#">
                <i class="fa fa-university fax2"></i>
                <span>Booth Info</span>
                <i class="fa fa-angle-left pull-right"></i>
              </a>
              <ul class="treeview-menu">
                <li><a href="/Tabs/Administration/ViewBoothStock.aspx"><i class="fa fa-circle-o"></i>View Booth Stock</a></li>
                   <li><a href="/Tabs/Administration/ViewBoothUserSales.aspx"><i class="fa fa-circle-o"></i>Booth User Sale</a></li>
               <li><a href="/Tabs/Reports/Boothitemwisesalessummary.aspx"><i class="fa fa-circle-o"></i>BoothSummary Itemwise </a></li> 
                 <li><a href="/Tabs/Reports/BoothBillWiseSalesSummary.aspx"><i class="fa fa-circle-o"></i>BoothSummary Billwise </a></li> 
                <li><a href="/Tabs/Reports/BoothSalesAnalysisUsers.aspx"><i class="fa fa-circle-o"></i>Booth Sales Analysis</a></li>
                    <li><a href="/Tabs/Reports/BoothroutewiseSalesSummary.aspx"><i class="fa fa-circle-o"></i>Booth Sale Summary</a></li>
                 
                   
                  
              </ul>
            </li>
          
      <li class="treeview">
              <a href="#">
                <i class="fa fa-truck fax2"></i>
                <span>Dispatch</span>
                <i class="fa fa-angle-left pull-right"></i>
              </a>
              <ul class="treeview-menu">
                   <li><a href="/Tabs/Administration/BoothPlaceOrder.aspx"><i class="fa fa-circle-o"></i>  Place Booth Order</a></li>
                 <%--  <li><a href="/Tabs/Administration/GenerateBillForBooth.aspx"><i class="fa fa-circle-o"></i>  Gnerate Bill</a></li>--%>
                  <%--<li><a href="/Tabs/Administration/ViewDispatchOrders.aspx"><i class="fa fa-circle-o"></i> View Dispatch Order</a></li>--%>
                   <li><a href="/Tabs/Administration/ViewDispatchSummary.aspx"><i class="fa fa-circle-o"></i> Dispatch Summary</a></li>
                    <li><a href="/Tabs/Administration/EditDispatchs.aspx"><i class="fa fa-circle-o"></i> Edit Dispatch </a></li>
                 
                   <li><a href="/Tabs/Administration/EditReturnedTrays.aspx"><i class="fa fa-circle-o"></i>Edit Returned Trays</a></li>
                   <li><a href="/Tabs/Administration/EditReturnScheme.aspx"><i class="fa fa-circle-o"></i>Edit Return Scheme</a></li>
                  <li><a href="/Tabs/Administration/EditReturnedProducts.aspx"><i class="fa fa-circle-o"></i>Edit Returned Products</a></li>
                  <li><a href="/Tabs/Administration/ViewDispatchSummaryUsers.aspx"><i class="fa fa-circle-o"></i> Dispatch Summary Shiftwise</a></li>
                    <li><a href="/Tabs/Administration/ViewDispatchUserShiftwise.aspx"><i class="fa fa-circle-o"></i> View Dispatch UserShiftwise</a></li>
                 <li><a href="/Tabs/Administration/AddReturnedItems.aspx"><i class="fa fa-circle-o"></i> Returned Products</a></li>
                 <li><a href="/Tabs/Administration/ReturnedTrays.aspx"><i class="fa fa-circle-o"></i> Returned Trays</a></li>
                   <li><a href="/Tabs/Administration/ReturnScheme.aspx"><i class="fa fa-circle-o"></i> Returned Scheme</a></li>
                      <li><a href="/Tabs/Despatch/RoutewiseReturnTraysReport.aspx"><i class="fa fa-circle-o"></i> Routewise Return Trays Report</a></li>
                    <li><a href="/Tabs/Despatch/RoutewiseReturnIceBoxReport.aspx"><i class="fa fa-circle-o"></i> Routewise Return IceBox Report</a></li>
                  <li><a href="/Tabs/Despatch/RoutewiseReturnCartonReport.aspx"><i class="fa fa-circle-o"></i> Routewise Return Carton Report</a></li>
                 <li><a href="/Tabs/Despatch/RoutewiseReturnOtherReport.aspx"><i class="fa fa-circle-o"></i> Routewise Return Other Report</a></li>

                   <li><a href="/Tabs/Despatch/SalesmanwiseReturnTraysReport.aspx"><i class="fa fa-circle-o"></i> Salesmanwise Return Trays Report</a></li>
                    <li><a href="/Tabs/Despatch/SalesmanwiseReturnIceBoxReport.aspx"><i class="fa fa-circle-o"></i> Salesmanwise Return IceBox Report</a></li>
                  <li><a href="/Tabs/Despatch/SalesmanwiseCartonReport.aspx"><i class="fa fa-circle-o"></i> Salesmanwise Return Carton Report</a></li>
                 <li><a href="/Tabs/Despatch/SalesmanwiseOtherReport.aspx"><i class="fa fa-circle-o"></i> Salesmanwise Return Other Report</a></li>
                 
           <li  class="treeview">
               <a href="#">
                <i class="fa fa-file"></i>
                <span>Agency Sales Report</span>
                <i class="fa fa-angle-left pull-right"></i>
              </a>
               <ul class="treeview-menu">
                 <li><a href="/Tabs/Reports/ItemwiseSalesSummary.aspx"><i class="fa fa-circle-o"></i>Summary Item wise </a></li> 
                 <li><a href="/Tabs/Reports/BillwiseSaleSummary.aspx"><i class="fa fa-circle-o"></i>Summary Bill wise </a></li> 
                   <li><a href="/Tabs/Reports/RoutewiseSalesSummary.aspx"><i class="fa fa-circle-o"></i>Summary Route wise </a></li>
                  <li><a href="/Tabs/Reports/SalesAnalysisItemwise.aspx"><i class="fa fa-circle-o"></i>Sales Analysis Item wise</a></li>
                  </ul> </li>

                 
               
              </ul>
            </li> 
        <li class="treeview">
              <a href="#">
                <i class="fa fa-tag fax2"></i>
                <span>Cashier Settlement</span>
                <i class="fa fa-angle-left pull-right"></i>
              </a>
              <ul class="treeview-menu">
                <li><a href="/Tabs/Administration/CashierSettlement.aspx"><i class="fa fa-circle-o"></i> Cashier Settlement</a></li>
                  
               <li  class="treeview">
               <a href="#">
                <i class="fa fa-file"></i>
                <span>Agency Sales Report</span>
                <i class="fa fa-angle-left pull-right"></i>
              </a>
               <ul class="treeview-menu">
                 <li><a href="/Tabs/Reports/ItemwiseSalesSummary.aspx"><i class="fa fa-circle-o"></i>Summary Item wise </a></li> 
                 <li><a href="/Tabs/Reports/BillwiseSaleSummary.aspx"><i class="fa fa-circle-o"></i>Summary Bill wise </a></li> 
                   <li><a href="/Tabs/Reports/RoutewiseSalesSummary.aspx"><i class="fa fa-circle-o"></i>Summary Route wise </a></li>
                  <li><a href="/Tabs/Reports/SalesAnalysisItemwise.aspx"><i class="fa fa-circle-o"></i>Sales Analysis Item wise</a></li>
                  </ul> </li>
              </ul>
            </li> 

             <li class="treeview">
              <a href="#">
                <i class="fa fa-tag fax2"></i>
                <span>Marketing</span>
                <i class="fa fa-line-chart pull-right"></i>
              </a>
              <ul class="treeview-menu">
                <li><a href="/Tabs/Marketing/AgentSchemeDetails.aspx"><i class="fa fa-circle-o"></i> Agency Scheme Details</a></li>
                  <li><a href="/Tabs/Marketing/AgentSchemeSummary.aspx"><i class="fa fa-circle-o"></i>Agency Scheme Summary</a></li>
                    <li><a href="/Tabs/Marketing/SchemeRefund.aspx"><i class="fa fa-circle-o"></i>Agency SchemeRefund  </a></li>
              <li><a href="/Tabs/Marketing/ItemwiseSalesSummaryForMarketing.aspx"><i class="fa fa-circle-o"></i>Itemwise Sales Summary  </a></li>
                
                   <li><a href="/Tabs/Marketing/BillwiseSalesSummaryforMarketing.aspx"><i class="fa fa-circle-o"></i> Bill Wise Sales Summary</a></li>
                 <%--  <li><a href="/Tabs/Marketing/IncentiveSetupScreen.aspx"><i class="fa fa-circle-o"></i> Incentive Rate Setup </a></li>--%>
                  <li><a href="/Tabs/Marketing/PartywiseIncentiveSummary.aspx"><i class="fa fa-circle-o"></i>Partywise Incentive Summary </a></li>
                  <li><a href="/Tabs/Marketing/MarketingSalesAnalysisItemwise.aspx"><i class="fa fa-circle-o"></i>Sales Analysis Itemwise </a></li>
                  <li><a href="/Tabs/Marketing/AgencyCloserScreen.aspx"><i class="fa fa-circle-o"></i>Agency Closer  </a></li>
                   
                <%--<li><a href="/Tabs/Marketing/DamageReplacementRateSetup.aspx"><i class="fa fa-circle-o"></i>Damage Replacement RateSetup  </a></li>--%>
                  
               
               
                   <li><a href="/Tabs/Marketing/RefundSchemeSummary.aspx"><i class="fa fa-circle-o"></i>Refund Scheme Summary  </a></li>
               
                   <li><a href="/Tabs/Marketing/AgentListNotPlacedOrder.aspx"><i class="fa fa-circle-o"></i>AgentList Not Placed Order  </a></li>
                 <%-- <li><a href="/Tabs/Marketing/NewAgentlistSummary.aspx"><i class="fa fa-circle-o"></i>New Agent List  </a></li>--%>
                   <li><a href="/Tabs/Marketing/NewAgentList.aspx"><i class="fa fa-circle-o"></i>New Agent List  </a></li>
                  <li><a href="/Tabs/Marketing/AgentSlabReportList.aspx"><i class="fa fa-circle-o"></i>AgentList Basis of Slab</a></li>
                   <li><a href="/Tabs/Marketing/DeactivateAgentList.aspx"><i class="fa fa-circle-o"></i>Deactivate Agent List  </a></li>
                    <li><a href="/Tabs/Marketing/PartywiseDamageReplacementSummary.aspx"><i class="fa fa-circle-o"></i>Partywise DamageReplacement Summary</a></li>
                   <li><a href="/Tabs/Marketing/ItemwisePurchaseAgentList.aspx"><i class="fa fa-circle-o"></i>ItemWise PurchaseAgent List  </a></li>
                    <li><a href="/Tabs/Marketing/AmountwiseIceCreamReport.aspx"><i class="fa fa-circle-o"></i>Amount Wise IceCream PurchaseAgent List  </a></li>
                <li  class="treeview">
               <a href="#">
                <i class="fa fa-file"></i>
                <span>Staff Sales</span>
                <i class="fa fa-angle-left pull-right"></i>
              </a>
                       <ul class="treeview-menu">
                     <li><a href="/Tabs/Marketing/BillwiseStaffSalesSummary.aspx"><i class="fa fa-circle-o"></i>Billwise Staff Sales Summary  </a></li>
                    
                      <li><a href="/Tabs/Marketing/ItemwiseStaffSalesSummary.aspx"><i class="fa fa-circle-o"></i>Itemwise Staff Sales Summary  </a></li>
                         <li><a href="/Tabs/Marketing/StaffAccountSalesSummary.aspx"><i class="fa fa-circle-o"></i> Staff A/C Sales Summary</a></li>

                       </ul>
                    </li>
                  <li  class="treeview">
               <a href="#">
                <i class="fa fa-file"></i>
                <span>Comparison Report</span>
                <i class="fa fa-angle-left pull-right"></i>
              </a>
               <ul class="treeview-menu">
                     <li><a href="/Tabs/Marketing/SalesComparison.aspx"><i class="fa fa-circle-o"></i> Sales Comparison Summary</a></li>
                    <li><a href="/Tabs/Marketing/DespatchComparisonReport.aspx"><i class="fa fa-circle-o"></i> Dispatch Comparison Summary</a></li>
                  <li><a href="/Tabs/Marketing/ReturnComparisonReport.aspx"><i class="fa fa-circle-o"></i> Return Comparison Summary</a></li>
                 <li><a href="/Tabs/Marketing/SpotDamageComparisonReport.aspx"><i class="fa fa-circle-o"></i> Spot-Damage Comparison Summary</a></li>
                      <li><a href="/Tabs/Marketing/DispatchReturnComparison.aspx"><i class="fa fa-circle-o"></i>Dispatch Agency Return Comparison  </a></li>
                   </ul>
                       <li><a href="/Tabs/Marketing/ActiveInactiveIssues.aspx"><i class="fa fa-circle-o"></i>Active Inactive Issue</a></li>
                   <li><a href="/Tabs/Marketing/CorrectiveActionOnIssue.aspx"><i class="fa fa-circle-o"></i>Corrective Action On Issue</a></li>
                   <li><a href="/Tabs/Marketing/IssuesRegistration.aspx"><i class="fa fa-circle-o"></i>Issue Registration</a></li>
                    <li><a href="/Tabs/Marketing/Mass Issue.aspx"><i class="fa fa-circle-o"></i>Mass Issue</a></li>

                    
              </ul>
                 
            </li> 
                  

        
   <%--   <li class="treeview">
              <a href="#">
                <i class="fa fa-file"></i>
                <span>Reports</span>
                <i class="fa fa-angle-left pull-right"></i>
              </a>
              <ul class="treeview-menu">
                <li><a href="/Reports/ProductWIseSealsReports.aspx"><i class="fa fa-circle-o"></i> Product wise Sales</a></li>
                <li><a href="/Reports/AgentSchemeReport.aspx"><i class="fa fa-circle-o"></i>Agent Scheme Report</a></li>
                <li><a href="/Reports/BillsReports.aspx"><i class="fa fa-circle-o"></i> Cash / Credit Bill</a></li>
                <li><a href="/Reports/PartyWiseScheme.aspx"><i class="fa fa-circle-o"></i> Party Wise Scheme</a></li>
                <li><a href="/Reports/StaffACCSaleSummary.aspx"><i class="fa fa-circle-o"></i>Staff ACC Sale Summary</a></li> 
               
                 
                 
                   

              </ul>
            </li>--%>
        
       <li class="treeview">
              <a href="#">
                <i class="glyphicon glyphicon-road"></i>
                <span>Transport Master</span>
                <i class="fa fa-angle-left pull-right"></i>
              </a>
              <ul class="treeview-menu">
               
                   <li><a href="/Tabs/TransportModule/TransportBrandMaster.aspx"><i class="fa fa-circle-o"></i> Brand master</a></li>
                      <li><a href="/Tabs/TransportModule/TranportModelMaster.aspx"><i class="fa fa-circle-o"></i> Model master</a></li>  
                       <li><a href="/Tabs/TransportModule/Configure.aspx"><i class="fa fa-circle-o"></i> Config master</a></li>    
                     <li><a href="/Tabs/TransportModule/VehicleRouteMap.aspx"><i class="fa fa-circle-o"></i> Vehicle Route Map</a></li> 
                      <li><a href="/Tabs/TransportModule/VehicleTarifDetails.aspx"><i class="fa fa-circle-o"></i> Vehicle Tariff</a></li>     
                  <li><a href="/Tabs/TransportModule/VehicleOperations.aspx"><i class="fa fa-circle-o"></i> Vehicle Out Operation</a></li>
                    <li><a href="/Tabs/TransportModule/ProductSupplyOutOperation.aspx"><i class="fa fa-circle-o"></i>ProductSupplyOutOperation</a></li> 
                      <li><a href="/Tabs/TransportModule/VehicleInOperation.aspx"><i class="fa fa-circle-o"></i>Vechicle In Operation</a></li> 
                      <li><a href="/Tabs/TransportModule/FuelDetails.aspx"><i class="fa fa-circle-o"></i> Fuel Details Info</a></li>  
                   <li><a href="/Tabs/TransportModule/FuelPumpMaster.aspx"><i class="fa fa-circle-o"></i> Fuel Pump Info</a></li>                    
                       <li><a href="/Tabs/TransportModule/TransportDetails.aspx"><i class="fa fa-circle-o"></i> Transport Information</a></li>
                    <li><a href="/Tabs/TransportModule/VehicleMaintenance.aspx"><i class="fa fa-circle-o"></i>Transport Maintenance</a></li>
                     <li><a href="/Tabs/TransportModule/PUCMaintenance.aspx"><i class="fa fa-circle-o"></i>Transport PUC Maintenance</a></li>
                    <li><a href="/Tabs/TransportModule/InsuranceMaintenance.aspx"><i class="fa fa-circle-o"></i>Transport Ins. Maintenance</a></li>
                      <li><a href="/Tabs/TransportModule/TransportReports/FuelListDateWise.aspx"><i class="fa fa-circle-o"></i>Fuel List Date Wise</a></li>
                    <li><a href="/Tabs/TransportModule/TransportReports/InternalReportofVehicleSection.aspx"><i class="fa fa-circle-o"></i>InternalReportVehicleSection</a></li>
                    <li><a href="/Tabs/TransportModule/TransportReports/MilkSupplyVehicleReportRoutewise.aspx"><i class="fa fa-circle-o"></i>MilkSupplyVehicleReportRoutewise</a></li>
                    <li><a href="/Tabs/TransportModule/TransportReports/VehicleRouteOperationSummary.aspx"><i class="fa fa-circle-o"></i>VehicleRouteOperationSummary</a></li>
                <li><a href="/Tabs/TransportModule/RouteWiseScheduleTime.aspx"><i class="fa fa-circle-o"></i>RouteWiseScheduleTime</a></li>
                
              </ul>
            </li> 
            
                <li class="treeview">
              <a href="#">
                <i class="fa fa-tag"></i>
                <span>Procurement</span>
                <i class="fa fa-angle-left pull-right"></i>
              </a>
              <ul class="treeview-menu">
                   <li><a href="/Tabs/Procurement/VehicleType.aspx"><i class="fa fa-circle-o"></i>Vehicle Model</a></li>
                    <li><a href="/Tabs/Procurement/VehicleMaster.aspx"><i class="fa fa-circle-o"></i>VehicleMaster</a></li>
                  <li><a href="/Tabs/Procurement/ReceiveDisposalheadmaster.aspx"><i class="fa fa-circle-o"></i>Receive & Dispose Master</a></li>
                
                  <li><a href="/Tabs/Procurement/AddMilkCollectionRoute.aspx"><i class="fa fa-circle-o"></i>Milk Collection Route Profile</a></li> 
                
                
                <li><a href="/Tabs/Procurement/AddMilkSuppliersProfile.aspx"><i class="fa fa-circle-o"></i>Milk Supplier Profile</a></li> 
                <li><a href="/Tabs/Procurement/AddSuppliersLoanInfo.aspx"><i class="fa fa-circle-o"></i> Supplier Loan Info</a></li> 
                  <%--   <li><a href="/Tabs/Procurement/RawMilkTariff.aspx"><i class="fa fa-circle-o"></i>RawMilkTarrif</a></li>--%>
                    <li><a href="/Tabs/Procurement/MilkCollectionDetails.aspx"><i class="fa fa-circle-o"></i>Milk Collection Details</a></li>
                     <li><a href="/Tabs/Procurement/CheckList.aspx"><i class="fa fa-circle-o"></i>Check List </a></li>
                    <li><a href="/Tabs/Procurement/CalulateRawMilkPurchase.aspx"><i class="fa fa-circle-o"></i>Raw Milk Rate Calculation</a></li>
                <%--<li><a href="/Tabs/Procurement/AddSupplierBankDetails.aspx"><i class="fa fa-circle-o"></i>Add Supplier Bank Details</a></li> --%>
                    <li><a href="/Tabs/Procurement/Supplierwiserawmilkqtyqlty.aspx"><i class="fa fa-circle-o"></i>Supplier Wise Raw Milk Qty and Qlty. Report</a></li>
                <li><a href="/Tabs/Procurement/AddSupplierSchemeBonus.aspx"><i class="fa fa-circle-o"></i>Yearwise Scheme Bonus</a></li> 
                <li><a href="/Tabs/Procurement/SupplierAdvanceInfo.aspx"><i class="fa fa-circle-o"></i> Vehicle Advance Info</a></li> 
                  <li><a href="/Tabs/Procurement/AddSupplierRDInfo.aspx"><i class="fa fa-circle-o"></i> Supplier RD Info</a></li>
                 <%-- <li><a href="/Tabs/Procurement/VehicleTariff.aspx"><i class="fa fa-circle-o"></i> Vehicle Tariff Info</a></li>--%>
                
                   <li><a href="/Tabs/Procurement/PaymentSummary.aspx"><i class="fa fa-circle-o"></i>Payment Summary</a></li>
                  <li><a href="/Tabs/Procurement/MilkCollectionTransport.aspx"><i class="fa fa-circle-o"></i>Vehicle IN-Out Entry</a></li>
              
                  <li><a href="/Tabs/Procurement/RawMilkStockRegister.aspx"><i class="fa fa-circle-o"></i>MilkReceiving/Disposing Details</a></li>
                 
                  <li><a href="/Tabs/Procurement/RawMilkPaymentListViaBank.aspx"><i class="fa fa-circle-o"></i>Raw Milk Payment List Via Bank</a></li>
                    <li><a href="/Tabs/Procurement/Transaction.aspx"><i class="fa fa-circle-o"></i>Transaction Summary</a></li>
                   <li><a href="/Tabs/Procurement/MonthlyRawMilkPurchaseSummary.aspx"><i class="fa fa-circle-o"></i>Monthly Raw Milk Purchase Summary</a></li>
                      <li><a href="/Tabs/Procurement/MilkCollectionTransportBill.aspx"><i class="fa fa-circle-o"></i>Milk Collection Transport Bill</a></li>
              </ul>
            </li>
            
            <%--<li class="header">LABELS</li>--%>
        
          </ul>
</asp:Panel>

<asp:Panel runat="server" ID="pnlReception" Visible="false">
        <ul class="sidebar-menu">    
            <li class="treeview">
              <a href="#">
                <i class="fa fa-tag"></i>
                <span style="width:220px">Reception (Order & Billing)</span>
                <i class="fa fa-angle-left pull-right"></i>
              </a>
              <ul class="treeview-menu" style="width:220px">
                <li><a href="/Tabs/Reception/PlaceOrderRoutewise.aspx"><i class="fa fa-circle-o"></i> Routewise Agency Order</a></li>
                <li><a href="/Tabs/Reception/PlaceOrderEmpRoutewise.aspx"><i class="fa fa-circle-o"></i> Routewise Employee Order</a></li>
                <li><a href="/Tabs/Reception/PlaceOrder.aspx"><i class="fa fa-circle-o"></i>  Daily Order</a></li>
                <li><a href="/Tabs/Reception/EditOrder.aspx"><i class="fa fa-circle-o"></i>Edit Order</a></li>
                  <li><a href="/Tabs/Reception/CancelOrder.aspx"><i class="fa fa-circle-o"></i>Cancel Order</a></li>
                <li><a href="/Tabs/Reception/OrderQuantity.aspx"><i class="fa fa-circle-o"></i>Order Summary</a></li>
                <li><a href="/Tabs/Reception/GenrateBillThermal.aspx"><i class="fa fa-circle-o"></i>Generate Bill</a></li>
             <%--   <li><a href="/Tabs/Reception/GenrateBill.aspx"><i class="fa fa-circle-o"></i> Generate Bill</a></li>--%>
                <li><a href="/Tabs/Reception/DuplicateBillForAgent.aspx"><i class="fa fa-circle-o"></i>Orderwise Sales Bill</a></li>
           <%--     <li><a href="/Tabs/Administration/BillSequence.aspx"><i class="fa fa-circle-o"></i> Bill Sequence</a></li>--%>
                <li><a href="/Tabs/Marketing/AgentListNotPlacedOrder.aspx"><i class="fa fa-circle-o"></i>Agent Not Placed Order</a></li>
                  <li><a href="/Tabs/Reception/ItemwiseOrderSummary.aspx"><i class="fa fa-circle-o"></i>Itemwise Order Summary</a></li>
                <li><a href="/Tabs/Reception/RatewiseOrderSummary.aspx"><i class="fa fa-circle-o"></i>Ratewise Order Summary</a></li>
                    <li><a href="/Tabs/Administration/OrderDemandStatement.aspx"><i class="fa fa-circle-o"></i>Order Demand Statement</a></li>
                
              </ul>
            </li> 
        
          </ul>
</asp:Panel>

<asp:Panel runat="server" ID="pnlSales" Visible="false">
      <ul class="sidebar-menu">
           
             <li class="treeview">
              <a href="#">
                <i class="fa fa-archive"></i>
                <span>Booth Billing</span>
                <i class="fa fa-angle-left pull-right"></i>
              </a>
              <ul class="treeview-menu">
                  <li><a href="/Tabs/Sales/BoothStockLanding.aspx"><i class="fa fa-circle-o"></i>Stock Available</a></li>
                <li><a href="/Tabs/Sales/LocalBilling.aspx"><i class="fa fa-circle-o"></i>Local Sale</a></li>
                   <li><a href="/Tabs/Sales/AgentBilling.aspx"><i class="fa fa-circle-o"></i>Agent Sale</a></li>
                   <li><a href="/Tabs/Sales/EmployeeBilling.aspx"><i class="fa fa-circle-o"></i>Employee Sale</a></li>    
                  <li><a href="/Tabs/Sales/BoothReturnReplace.aspx"><i class="fa fa-circle-o"></i>Return Items</a></li>   
                  <li><a href="/Tabs/Sales/BoothPlaceOrder.aspx"><i class="fa fa-circle-o"></i>Booth Place Order</a></li>         
              </ul>
            </li>           
        
          </ul>
</asp:Panel>
<asp:Panel runat="server" ID="pnlDesptach" Visible="false">

    <ul class="sidebar-menu">
          <li class="treeview">
              <a href="#">
                <i class="fa fa-file"></i>
                <span style="width:220px">Dispatch Details</span>
                <i class="fa fa-angle-left pull-right"></i>
              </a>
              <ul class="treeview-menu" style="width:220px">
                <li><a href="/Tabs/Despatch/BoothPlaceOrder.aspx"><i class="fa fa-circle-o"></i>  Place Booth Order</a></li>
                   <%--<li><a href="/Tabs/Administration/GenerateBillForBooth.aspx"><i class="fa fa-circle-o"></i>  Gnerate Bill</a></li>--%>
                  <li><a href="/Tabs/Despatch/ViewDispatchOrders.aspx"><i class="fa fa-circle-o"></i> View Dispatch Order</a></li>

                      <li  class="treeview">
               <a href="#">
                <i class="fa fa-file"></i>
                <span>Shift Details</span>
                <i class="fa fa-angle-left pull-right"></i>
              </a>
                       <ul class="treeview-menu">
           <li><a href="/Tabs/Despatch/ViewDispatchUserShiftwise.aspx"><i class="fa fa-circle-o"></i>Shiftwise Item Summary</a></li>
                <li><a href="/Tabs/Despatch/ViewDispatchSummary.aspx"><i class="fa fa-circle-o"></i> Dispatch Summary</a></li>
                  <li><a href="/Tabs/Despatch/ViewDispatchSummaryUsers.aspx"><i class="fa fa-circle-o"></i> Dispatch Summary Routewise</a></li>
       </ul>
                    </li>

                     <li  class="treeview">
               <a href="#">
                <i class="fa fa-file"></i>
                <span>Returns</span>
                <i class="fa fa-angle-left pull-right"></i>
              </a>
                       <ul class="treeview-menu">
                  <li><a href="/Tabs/Despatch/AddReturnedItems.aspx"><i class="fa fa-circle-o"></i> Returned Products</a></li>
                
                  <li><a href="/Tabs/Despatch/ReturnScheme.aspx"><i class="fa fa-circle-o"></i> Returned Scheme</a></li>
                   <li><a href="/Tabs/Despatch/ReturnedTrays.aspx"><i class="fa fa-circle-o"></i> Returned Trays</a></li>
                           </ul>
                    </li>
                   <li  class="treeview">
               <a href="#">
                <i class="fa fa-file"></i>
                <span>Sales Summary</span>
                <i class="fa fa-angle-left pull-right"></i>
              </a>
                       <ul class="treeview-menu">
                 <li><a href="/Tabs/Despatch/ItemwiseSalesSummary.aspx"><i class="fa fa-circle-o"></i>Itemwise Sales Summary</a></li> 
                 <li><a href="/Tabs/Reports/BillwiseSaleSummary.aspx"><i class="fa fa-circle-o"></i>Bill Wise Sales Summary</a></li> 
                  <li><a href="/Tabs/Reports/SalesAnalysisItemwise.aspx"><i class="fa fa-circle-o"></i>Sales Analysis-Itemwise</a></li>
                   <li><a href="/Tabs/Despatch/RoutewiseSalesSummary.aspx"><i class="fa fa-circle-o"></i>Routewise Sales Summary</a></li> 

                       </ul>
                    </li>

                     <li  class="treeview">
               <a href="#">
                <i class="fa fa-file"></i>
                <span>Trays Report</span>
                <i class="fa fa-angle-left pull-right"></i>
              </a>
                       <ul class="treeview-menu">
                 <li><a href="/Tabs/Despatch/RoutewiseReturnTraysReport.aspx"><i class="fa fa-circle-o"></i> Routewise Return Trays Report</a></li>
                    <li><a href="/Tabs/Despatch/RoutewiseReturnIceBoxReport.aspx"><i class="fa fa-circle-o"></i> Routewise Return IceBox Report</a></li>
                  <li><a href="/Tabs/Despatch/RoutewiseReturnCartonReport.aspx"><i class="fa fa-circle-o"></i> Routewise Return Carton Report</a></li>
                 <li><a href="/Tabs/Despatch/RoutewiseReturnOtherReport.aspx"><i class="fa fa-circle-o"></i> Routewise Return Other Report</a></li>

                    <li><a href="/Tabs/Despatch/SalesmanwiseReturnTraysReport.aspx"><i class="fa fa-circle-o"></i> Salesmanwise Return Trays Report</a></li>
                    <li><a href="/Tabs/Despatch/SalesmanwiseReturnIceBoxReport.aspx"><i class="fa fa-circle-o"></i> Salesmanwise Return IceBox Report</a></li>
                  <li><a href="/Tabs/Despatch/SalesmanwiseCartonReport.aspx"><i class="fa fa-circle-o"></i> Salesmanwise Return Carton Report</a></li>
                 <li><a href="/Tabs/Despatch/SalesmanwiseOtherReport.aspx"><i class="fa fa-circle-o"></i> Salesmanwise Return Other Report</a></li>
                         </ul>
                    </li>
               
              </ul>
            </li> 

     </ul>
</asp:Panel>
            <asp:Panel runat="server" ID="pnlCashier" Visible="false">

    <ul class="sidebar-menu">
          <li class="treeview">
              <a href="#">
                <i class="fa fa-file"></i>
                <span>Cashier Settlement</span>
                <i class="fa fa-angle-left pull-right"></i>
              </a>
              <ul class="treeview-menu">
                <li><a href="/Tabs/Administration/CashierSettlement.aspx"><i class="fa fa-circle-o"></i> Cashier Settlement</a></li>
                  
               
              </ul>
            </li> 

     </ul>
</asp:Panel>
          <asp:Panel runat="server" ID="pnlTransport" Visible="false">

    <ul class="sidebar-menu">
          <li class="treeview">
              <a href="#">
                <i class="glyphicon glyphicon-road"></i>
                <span>Transport Master</span>
                <i class="fa fa-angle-left pull-right"></i>
              </a>
              <ul class="treeview-menu">
               
                  <li><a href="/Tabs/TransportModule/TransportBrandMaster.aspx"><i class="fa fa-circle-o"></i> Brand master</a></li>
                      <li><a href="/Tabs/TransportModule/TranportModelMaster.aspx"><i class="fa fa-circle-o"></i> Model master</a></li>  
                       <li><a href="/Tabs/TransportModule/Configure.aspx"><i class="fa fa-circle-o"></i> Config master</a></li>    
                     <li><a href="/Tabs/TransportModule/VehicleRouteMap.aspx"><i class="fa fa-circle-o"></i> Vehicle Route Map</a></li> 
                      <li><a href="/Tabs/TransportModule/VehicleTarifDetails.aspx"><i class="fa fa-circle-o"></i> Vehicle Tariff</a></li>     
                  <li><a href="/Tabs/TransportModule/VehicleOperations.aspx"><i class="fa fa-circle-o"></i> Vehicle Out Operation</a></li>
                    <li><a href="/Tabs/TransportModule/ProductSupplyOutOperation.aspx"><i class="fa fa-circle-o"></i>ProductSupplyOutOperation</a></li> 
                      <li><a href="/Tabs/TransportModule/VehicleInOperation.aspx"><i class="fa fa-circle-o"></i>Vechicle In Operation</a></li> 
                      <li><a href="/Tabs/TransportModule/FuelDetails.aspx"><i class="fa fa-circle-o"></i> Fuel Details Info</a></li>  
                   <li><a href="/Tabs/TransportModule/FuelPumpMaster.aspx"><i class="fa fa-circle-o"></i> Fuel Pump Info</a></li>                    
                       <li><a href="/Tabs/TransportModule/TransportDetails.aspx"><i class="fa fa-circle-o"></i> Transport Information</a></li>
                    <li><a href="/Tabs/TransportModule/VehicleMaintenance.aspx"><i class="fa fa-circle-o"></i>Transport Maintenance</a></li>
                     <li><a href="/Tabs/TransportModule/PUCMaintenance.aspx"><i class="fa fa-circle-o"></i>Transport PUC Maintenance</a></li>
                    <li><a href="/Tabs/TransportModule/InsuranceMaintenance.aspx"><i class="fa fa-circle-o"></i>Transport Ins. Maintenance</a></li>
                      <li><a href="/Tabs/TransportModule/TransportReports/FuelListDateWise.aspx"><i class="fa fa-circle-o"></i>Fuel List Date Wise</a></li>
                    <li><a href="/Tabs/TransportModule/TransportReports/InternalReportofVehicleSection.aspx"><i class="fa fa-circle-o"></i>InternalReportVehicleSection</a></li>
                    <li><a href="/Tabs/TransportModule/TransportReports/MilkSupplyVehicleReportRoutewise.aspx"><i class="fa fa-circle-o"></i>MilkSupplyVehicleReportRoutewise</a></li>
                    <li><a href="/Tabs/TransportModule/TransportReports/VehicleRouteOperationSummary.aspx"><i class="fa fa-circle-o"></i>VehicleRouteOperationSummary</a></li>
                <li><a href="/Tabs/TransportModule/RouteWiseScheduleTime.aspx"><i class="fa fa-circle-o"></i>RouteWiseScheduleTime</a></li>

              </ul>
            </li> 

     </ul>
</asp:Panel>   

       <asp:Panel runat="server" ID="pnlPurchase" Visible="false">

    <ul class="sidebar-menu">
          <li class="treeview">
              <a href="#">
                <i class="glyphicon glyphicon-road"></i>
                <span>Purchase</span>
                <i class="fa fa-angle-left pull-right"></i>
              </a>
              <ul class="treeview-menu">
                  <li><a href="/Tabs/Purchase/Dashboard.aspx"><i class="fa fa-circle-o"></i>Dashboard</a></li>
                  <li><a href="/Tabs/Purchase/RackSections.aspx"><i class="fa fa-circle-o"></i>RackSections</a></li>
                  <li><a href="/Tabs/Purchase/Categories.aspx"><i class="fa fa-circle-o"></i>Categories</a></li>
                  <li><a href="/Tabs/Purchase/Items.aspx"><i class="fa fa-circle-o"></i>Items</a></li>
                  <li><a href="/Tabs/Purchase/VendorRegistration.aspx"><i class="fa fa-circle-o"></i>Vendor Registration</a></li>
                  <li><a href="/Tabs/Purchase/ItemRates.aspx"><i class="fa fa-circle-o"></i>Item Rates</a></li>
                  
                  <li><a href="/Tabs/Purchase/IndentMaterial.aspx"><i class="fa fa-circle-o"></i>Indent</a></li>
                  <li><a href="/Tabs/Purchase/ComparativeStatement.aspx"><i class="fa fa-circle-o"></i>Comparative Statement</a></li>
                  <li><a href="/Tabs/Purchase/PurchaseRequests.aspx"><i class="fa fa-circle-o"></i>Purchase Request</a></li>
                  <li><a href="/Tabs/PurchaseM/ViewPrchsRequest.aspx"><i class="fa fa-circle-o"></i>View Requests</a></li>
                  <li><a href="/Tabs/Purchase/PurchaseOrder.aspx"><i class="fa fa-circle-o"></i>Purchase Order</a></li>
                  <li><a href="/Tabs/Purchase/ViewPurchaseOrder.aspx"><i class="fa fa-circle-o"></i>Print Orders</a></li>
                  <li><a href="/Tabs/Purchase/MaterialReceived.aspx"><i class="fa fa-circle-o"></i>Material Received</a></li>
              </ul>
            </li> 

     </ul>
</asp:Panel> 
        </section>
        <!-- /.sidebar -->
      </aside>
