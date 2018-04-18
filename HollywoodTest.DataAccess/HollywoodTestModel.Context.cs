﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HollywoodTest.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class HollywoodTestEntities : DbContext
    {
        public HollywoodTestEntities()
            : base("name=HollywoodTestEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbErrorLog> tbErrorLogs { get; set; }
        public virtual DbSet<tbEvent> tbEvents { get; set; }
        public virtual DbSet<tbEventDetail> tbEventDetails { get; set; }
        public virtual DbSet<tbEventDetailStatu> tbEventDetailStatus { get; set; }
        public virtual DbSet<tbTournament> tbTournaments { get; set; }
    
        public virtual int prtbErrorLog_Insert(string errorMessage, string source, Nullable<System.DateTime> date)
        {
            var errorMessageParameter = errorMessage != null ?
                new ObjectParameter("ErrorMessage", errorMessage) :
                new ObjectParameter("ErrorMessage", typeof(string));
    
            var sourceParameter = source != null ?
                new ObjectParameter("Source", source) :
                new ObjectParameter("Source", typeof(string));
    
            var dateParameter = date.HasValue ?
                new ObjectParameter("Date", date) :
                new ObjectParameter("Date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("prtbErrorLog_Insert", errorMessageParameter, sourceParameter, dateParameter);
        }
    
        public virtual int prtbEvent_Delete(Nullable<long> eventID)
        {
            var eventIDParameter = eventID.HasValue ?
                new ObjectParameter("EventID", eventID) :
                new ObjectParameter("EventID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("prtbEvent_Delete", eventIDParameter);
        }
    
        public virtual ObjectResult<prtbEvent_GetAllActiveEvent_Result> prtbEvent_GetAllActiveEvent()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prtbEvent_GetAllActiveEvent_Result>("prtbEvent_GetAllActiveEvent");
        }
    
        public virtual ObjectResult<prtbEvent_GetByTournamentID_Result> prtbEvent_GetByTournamentID(Nullable<long> tournamentID)
        {
            var tournamentIDParameter = tournamentID.HasValue ?
                new ObjectParameter("TournamentID", tournamentID) :
                new ObjectParameter("TournamentID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prtbEvent_GetByTournamentID_Result>("prtbEvent_GetByTournamentID", tournamentIDParameter);
        }
    
        public virtual ObjectResult<prtbEvent_GetOne_Result> prtbEvent_GetOne(Nullable<long> eventID)
        {
            var eventIDParameter = eventID.HasValue ?
                new ObjectParameter("EventID", eventID) :
                new ObjectParameter("EventID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prtbEvent_GetOne_Result>("prtbEvent_GetOne", eventIDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> prtbEvent_Insert(Nullable<long> fK_TournamentID, string eventName, Nullable<short> eventNumber, Nullable<System.DateTime> eventDateTime, Nullable<System.DateTime> eventEndDateTime, Nullable<bool> autoClose)
        {
            var fK_TournamentIDParameter = fK_TournamentID.HasValue ?
                new ObjectParameter("FK_TournamentID", fK_TournamentID) :
                new ObjectParameter("FK_TournamentID", typeof(long));
    
            var eventNameParameter = eventName != null ?
                new ObjectParameter("EventName", eventName) :
                new ObjectParameter("EventName", typeof(string));
    
            var eventNumberParameter = eventNumber.HasValue ?
                new ObjectParameter("EventNumber", eventNumber) :
                new ObjectParameter("EventNumber", typeof(short));
    
            var eventDateTimeParameter = eventDateTime.HasValue ?
                new ObjectParameter("EventDateTime", eventDateTime) :
                new ObjectParameter("EventDateTime", typeof(System.DateTime));
    
            var eventEndDateTimeParameter = eventEndDateTime.HasValue ?
                new ObjectParameter("EventEndDateTime", eventEndDateTime) :
                new ObjectParameter("EventEndDateTime", typeof(System.DateTime));
    
            var autoCloseParameter = autoClose.HasValue ?
                new ObjectParameter("AutoClose", autoClose) :
                new ObjectParameter("AutoClose", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("prtbEvent_Insert", fK_TournamentIDParameter, eventNameParameter, eventNumberParameter, eventDateTimeParameter, eventEndDateTimeParameter, autoCloseParameter);
        }
    
        public virtual int prtbEvent_Update(Nullable<long> eventID, Nullable<long> fK_TournamentID, string eventName, Nullable<short> eventNumber, Nullable<System.DateTime> eventDateTime, Nullable<System.DateTime> eventEndDateTime, Nullable<bool> autoClose)
        {
            var eventIDParameter = eventID.HasValue ?
                new ObjectParameter("EventID", eventID) :
                new ObjectParameter("EventID", typeof(long));
    
            var fK_TournamentIDParameter = fK_TournamentID.HasValue ?
                new ObjectParameter("FK_TournamentID", fK_TournamentID) :
                new ObjectParameter("FK_TournamentID", typeof(long));
    
            var eventNameParameter = eventName != null ?
                new ObjectParameter("EventName", eventName) :
                new ObjectParameter("EventName", typeof(string));
    
            var eventNumberParameter = eventNumber.HasValue ?
                new ObjectParameter("EventNumber", eventNumber) :
                new ObjectParameter("EventNumber", typeof(short));
    
            var eventDateTimeParameter = eventDateTime.HasValue ?
                new ObjectParameter("EventDateTime", eventDateTime) :
                new ObjectParameter("EventDateTime", typeof(System.DateTime));
    
            var eventEndDateTimeParameter = eventEndDateTime.HasValue ?
                new ObjectParameter("EventEndDateTime", eventEndDateTime) :
                new ObjectParameter("EventEndDateTime", typeof(System.DateTime));
    
            var autoCloseParameter = autoClose.HasValue ?
                new ObjectParameter("AutoClose", autoClose) :
                new ObjectParameter("AutoClose", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("prtbEvent_Update", eventIDParameter, fK_TournamentIDParameter, eventNameParameter, eventNumberParameter, eventDateTimeParameter, eventEndDateTimeParameter, autoCloseParameter);
        }
    
        public virtual int prtbEventDetail_Delete(Nullable<long> eventDetailID)
        {
            var eventDetailIDParameter = eventDetailID.HasValue ?
                new ObjectParameter("EventDetailID", eventDetailID) :
                new ObjectParameter("EventDetailID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("prtbEventDetail_Delete", eventDetailIDParameter);
        }
    
        public virtual ObjectResult<prtbEventDetail_GetByEventID_Result> prtbEventDetail_GetByEventID(Nullable<long> eventID)
        {
            var eventIDParameter = eventID.HasValue ?
                new ObjectParameter("EventID", eventID) :
                new ObjectParameter("EventID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prtbEventDetail_GetByEventID_Result>("prtbEventDetail_GetByEventID", eventIDParameter);
        }
    
        public virtual ObjectResult<prtbEventDetail_GetOne_Result> prtbEventDetail_GetOne(Nullable<long> eventDetailID)
        {
            var eventDetailIDParameter = eventDetailID.HasValue ?
                new ObjectParameter("EventDetailID", eventDetailID) :
                new ObjectParameter("EventDetailID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prtbEventDetail_GetOne_Result>("prtbEventDetail_GetOne", eventDetailIDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> prtbEventDetail_Insert(Nullable<long> fK_EventID, Nullable<long> fK_EventDetailStatusID, string eventDetailName, Nullable<short> eventDetailNumber, Nullable<decimal> eventDetailsOdd, Nullable<short> finishingPosition, Nullable<bool> firstTimer)
        {
            var fK_EventIDParameter = fK_EventID.HasValue ?
                new ObjectParameter("FK_EventID", fK_EventID) :
                new ObjectParameter("FK_EventID", typeof(long));
    
            var fK_EventDetailStatusIDParameter = fK_EventDetailStatusID.HasValue ?
                new ObjectParameter("FK_EventDetailStatusID", fK_EventDetailStatusID) :
                new ObjectParameter("FK_EventDetailStatusID", typeof(long));
    
            var eventDetailNameParameter = eventDetailName != null ?
                new ObjectParameter("EventDetailName", eventDetailName) :
                new ObjectParameter("EventDetailName", typeof(string));
    
            var eventDetailNumberParameter = eventDetailNumber.HasValue ?
                new ObjectParameter("EventDetailNumber", eventDetailNumber) :
                new ObjectParameter("EventDetailNumber", typeof(short));
    
            var eventDetailsOddParameter = eventDetailsOdd.HasValue ?
                new ObjectParameter("EventDetailsOdd", eventDetailsOdd) :
                new ObjectParameter("EventDetailsOdd", typeof(decimal));
    
            var finishingPositionParameter = finishingPosition.HasValue ?
                new ObjectParameter("FinishingPosition", finishingPosition) :
                new ObjectParameter("FinishingPosition", typeof(short));
    
            var firstTimerParameter = firstTimer.HasValue ?
                new ObjectParameter("FirstTimer", firstTimer) :
                new ObjectParameter("FirstTimer", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("prtbEventDetail_Insert", fK_EventIDParameter, fK_EventDetailStatusIDParameter, eventDetailNameParameter, eventDetailNumberParameter, eventDetailsOddParameter, finishingPositionParameter, firstTimerParameter);
        }
    
        public virtual int prtbEventDetail_Update(Nullable<long> eventDetailID, Nullable<long> fK_EventID, Nullable<long> fK_EventDetailStatusID, string eventDetailName, Nullable<short> eventDetailNumber, Nullable<decimal> eventDetailsOdd, Nullable<short> finishingPosition, Nullable<bool> firstTimer)
        {
            var eventDetailIDParameter = eventDetailID.HasValue ?
                new ObjectParameter("EventDetailID", eventDetailID) :
                new ObjectParameter("EventDetailID", typeof(long));
    
            var fK_EventIDParameter = fK_EventID.HasValue ?
                new ObjectParameter("FK_EventID", fK_EventID) :
                new ObjectParameter("FK_EventID", typeof(long));
    
            var fK_EventDetailStatusIDParameter = fK_EventDetailStatusID.HasValue ?
                new ObjectParameter("FK_EventDetailStatusID", fK_EventDetailStatusID) :
                new ObjectParameter("FK_EventDetailStatusID", typeof(long));
    
            var eventDetailNameParameter = eventDetailName != null ?
                new ObjectParameter("EventDetailName", eventDetailName) :
                new ObjectParameter("EventDetailName", typeof(string));
    
            var eventDetailNumberParameter = eventDetailNumber.HasValue ?
                new ObjectParameter("EventDetailNumber", eventDetailNumber) :
                new ObjectParameter("EventDetailNumber", typeof(short));
    
            var eventDetailsOddParameter = eventDetailsOdd.HasValue ?
                new ObjectParameter("EventDetailsOdd", eventDetailsOdd) :
                new ObjectParameter("EventDetailsOdd", typeof(decimal));
    
            var finishingPositionParameter = finishingPosition.HasValue ?
                new ObjectParameter("FinishingPosition", finishingPosition) :
                new ObjectParameter("FinishingPosition", typeof(short));
    
            var firstTimerParameter = firstTimer.HasValue ?
                new ObjectParameter("FirstTimer", firstTimer) :
                new ObjectParameter("FirstTimer", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("prtbEventDetail_Update", eventDetailIDParameter, fK_EventIDParameter, fK_EventDetailStatusIDParameter, eventDetailNameParameter, eventDetailNumberParameter, eventDetailsOddParameter, finishingPositionParameter, firstTimerParameter);
        }
    
        public virtual int prtbTournament_Delete(Nullable<long> tournamentID)
        {
            var tournamentIDParameter = tournamentID.HasValue ?
                new ObjectParameter("TournamentID", tournamentID) :
                new ObjectParameter("TournamentID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("prtbTournament_Delete", tournamentIDParameter);
        }
    
        public virtual ObjectResult<prtbTournament_GetAll_Result> prtbTournament_GetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prtbTournament_GetAll_Result>("prtbTournament_GetAll");
        }
    
        public virtual ObjectResult<Nullable<int>> prtbTournament_Insert(string tournamentName)
        {
            var tournamentNameParameter = tournamentName != null ?
                new ObjectParameter("TournamentName", tournamentName) :
                new ObjectParameter("TournamentName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("prtbTournament_Insert", tournamentNameParameter);
        }
    
        public virtual int prtbTournament_Update(Nullable<long> tournamentID, string tournamentName)
        {
            var tournamentIDParameter = tournamentID.HasValue ?
                new ObjectParameter("TournamentID", tournamentID) :
                new ObjectParameter("TournamentID", typeof(long));
    
            var tournamentNameParameter = tournamentName != null ?
                new ObjectParameter("TournamentName", tournamentName) :
                new ObjectParameter("TournamentName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("prtbTournament_Update", tournamentIDParameter, tournamentNameParameter);
        }
    }
}