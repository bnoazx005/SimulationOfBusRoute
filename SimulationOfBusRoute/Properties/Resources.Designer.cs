﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SimulationOfBusRoute.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SimulationOfBusRoute.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Animation {
            get {
                object obj = ResourceManager.GetObject("Animation", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap mAddBusButtonImage {
            get {
                object obj = ResourceManager.GetObject("mAddBusButtonImage", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Добавление.
        /// </summary>
        internal static string mAddMode {
            get {
                return ResourceManager.GetString("mAddMode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap mAddNodeButtonActiveImage {
            get {
                object obj = ResourceManager.GetObject("mAddNodeButtonActiveImage", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap mAddNodeButtonImage {
            get {
                object obj = ResourceManager.GetObject("mAddNodeButtonImage", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to addRouteNodeButton.
        /// </summary>
        internal static string mAddRouteNodeButtonName {
            get {
                return ResourceManager.GetString("mAddRouteNodeButtonName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap mBusEditorButtonImage {
            get {
                object obj = ResourceManager.GetObject("mBusEditorButtonImage", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to busEditorButton.
        /// </summary>
        internal static string mBusEditorButtonName {
            get {
                return ResourceManager.GetString("mBusEditorButtonName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Автобус № {0}.
        /// </summary>
        internal static string mBusesHeaderInEditor {
            get {
                return ResourceManager.GetString("mBusesHeaderInEditor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to График зависимости текущей вместимости автобуса от момента времени.
        /// </summary>
        internal static string mBusesPlotCapacityTitle {
            get {
                return ResourceManager.GetString("mBusesPlotCapacityTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to График зависимости количества выходящих людей из автобуса от момента времени.
        /// </summary>
        internal static string mBusesPlotExcurrentPassengersTitle {
            get {
                return ResourceManager.GetString("mBusesPlotExcurrentPassengersTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to График зависимости количества входящих людей из автобуса от момента времени.
        /// </summary>
        internal static string mBusesPlotIncomingPassengersTitle {
            get {
                return ResourceManager.GetString("mBusesPlotIncomingPassengersTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to График, отражающий время прибытия автобуса на соотетствующие остановки.
        /// </summary>
        internal static string mBusesPlotTotalTimeTitle {
            get {
                return ResourceManager.GetString("mBusesPlotTotalTimeTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to График, отражающий время, затраченное на высадку и посадку, автобусом.
        /// </summary>
        internal static string mBusesPlotWaitingTimeTitle {
            get {
                return ResourceManager.GetString("mBusesPlotWaitingTimeTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to decl {{{0}    time : Time;{0}    v : Vector({1});{0}}}.
        /// </summary>
        internal static string mBusesVelocitiesHeaderTemplate {
            get {
                return ResourceManager.GetString("mBusesVelocitiesHeaderTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to busesVelocitiesCode.
        /// </summary>
        internal static string mBusesVelocitiesName {
            get {
                return ResourceManager.GetString("mBusesVelocitiesName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap mCopyButtonImage {
            get {
                object obj = ResourceManager.GetObject("mCopyButtonImage", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap mCutButtonImage {
            get {
                object obj = ResourceManager.GetObject("mCutButtonImage", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap mDataEditorButtonImage {
            get {
                object obj = ResourceManager.GetObject("mDataEditorButtonImage", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to dataEditorButton.
        /// </summary>
        internal static string mDataEditorButtonName {
            get {
                return ResourceManager.GetString("mDataEditorButtonName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to case|default|decl|in.
        /// </summary>
        internal static string mDataEditorHighlightingGroup1 {
            get {
                return ResourceManager.GetString("mDataEditorHighlightingGroup1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Time|Matrix|Vector.
        /// </summary>
        internal static string mDataEditorHighlightingGroup2 {
            get {
                return ResourceManager.GetString("mDataEditorHighlightingGroup2", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to .
        /// </summary>
        internal static string mDataEditorHighlightingGroup3 {
            get {
                return ResourceManager.GetString("mDataEditorHighlightingGroup3", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ошибка!.
        /// </summary>
        internal static string mErrorMessageTitle {
            get {
                return ResourceManager.GetString("mErrorMessageTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap mLoadRouteButtonImage {
            get {
                object obj = ResourceManager.GetObject("mLoadRouteButtonImage", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to matrixOfIntensitiesCode.
        /// </summary>
        internal static string mMatricesOfIntensitiesName {
            get {
                return ResourceManager.GetString("mMatricesOfIntensitiesName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Перемещение.
        /// </summary>
        internal static string mMoveMode {
            get {
                return ResourceManager.GetString("mMoveMode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap mMoveNodeButtonActiveImage {
            get {
                object obj = ResourceManager.GetObject("mMoveNodeButtonActiveImage", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap mMoveNodeButtonImage {
            get {
                object obj = ResourceManager.GetObject("mMoveNodeButtonImage", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to moveNodeButton.
        /// </summary>
        internal static string mMoveNodeButtonName {
            get {
                return ResourceManager.GetString("mMoveNodeButtonName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to FinishTimeOfSimulation.
        /// </summary>
        internal static string mOptionsFinishTimeOfSimulation {
            get {
                return ResourceManager.GetString("mOptionsFinishTimeOfSimulation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to NumOfSimulationSteps.
        /// </summary>
        internal static string mOptionsNumOfSimulationSteps {
            get {
                return ResourceManager.GetString("mOptionsNumOfSimulationSteps", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ProjectFilename.
        /// </summary>
        internal static string mOptionsProjectFilename {
            get {
                return ResourceManager.GetString("mOptionsProjectFilename", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to StartTimeOfSimulation.
        /// </summary>
        internal static string mOptionsStartTimeOfSimulation {
            get {
                return ResourceManager.GetString("mOptionsStartTimeOfSimulation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to stationsEditorCode.
        /// </summary>
        internal static string mOptionsStationsEditorCode {
            get {
                return ResourceManager.GetString("mOptionsStationsEditorCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to velocitiesEditorCode.
        /// </summary>
        internal static string mOptionsVelocitiesEditorCode {
            get {
                return ResourceManager.GetString("mOptionsVelocitiesEditorCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap mPasteButtonImage {
            get {
                object obj = ResourceManager.GetObject("mPasteButtonImage", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap mPauseSimulationButtonImage {
            get {
                object obj = ResourceManager.GetObject("mPauseSimulationButtonImage", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Текущие данные не были сохранены, сохранить их перед загрузкой новых?.
        /// </summary>
        internal static string mPreLoadSaveMessage {
            get {
                return ResourceManager.GetString("mPreLoadSaveMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap mQuitButtonImage {
            get {
                object obj = ResourceManager.GetObject("mQuitButtonImage", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap mRedoButtonImage {
            get {
                object obj = ResourceManager.GetObject("mRedoButtonImage", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Удаление.
        /// </summary>
        internal static string mRemoveMode {
            get {
                return ResourceManager.GetString("mRemoveMode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap mRemoveNodeButtonActiveImage {
            get {
                object obj = ResourceManager.GetObject("mRemoveNodeButtonActiveImage", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap mRemoveNodeButtonImage {
            get {
                object obj = ResourceManager.GetObject("mRemoveNodeButtonImage", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to removeRouteNodeButton.
        /// </summary>
        internal static string mRemoveRouteNodeButtonName {
            get {
                return ResourceManager.GetString("mRemoveRouteNodeButtonName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap mSaveRouteButtonImage {
            get {
                object obj = ResourceManager.GetObject("mSaveRouteButtonImage", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Выбор.
        /// </summary>
        internal static string mSelectionMode {
            get {
                return ResourceManager.GetString("mSelectionMode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap mSelectNodeButtonActiveImage {
            get {
                object obj = ResourceManager.GetObject("mSelectNodeButtonActiveImage", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap mSelectNodeButtonImage {
            get {
                object obj = ResourceManager.GetObject("mSelectNodeButtonImage", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to selectNodeButton.
        /// </summary>
        internal static string mSelectNodeButtonName {
            get {
                return ResourceManager.GetString("mSelectNodeButtonName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap mSettingsButtonImage {
            get {
                object obj = ResourceManager.GetObject("mSettingsButtonImage", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Задан неверный временной интервал.
        /// </summary>
        internal static string mSettingsIncorrectTimeIntervalErrorMessage {
            get {
                return ResourceManager.GetString("mSettingsIncorrectTimeIntervalErrorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to boolOptions.
        /// </summary>
        internal static string mSQLBoolOptionsTableName {
            get {
                return ResourceManager.GetString("mSQLBoolOptionsTableName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to buses.
        /// </summary>
        internal static string mSQLBusesTableName {
            get {
                return ResourceManager.GetString("mSQLBusesTableName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to busStationNodes.
        /// </summary>
        internal static string mSQLBusStationNodesTableName {
            get {
                return ResourceManager.GetString("mSQLBusStationNodesTableName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE IF NOT EXISTS boolOptions(name TEXT PRIMARY KEY, value INTEGER, FOREIGN KEY(name) REFERENCES options(name) ON DELETE CASCADE ON UPDATE CASCADE);.
        /// </summary>
        internal static string mSQLCreateBoolOptionsTable {
            get {
                return ResourceManager.GetString("mSQLCreateBoolOptionsTable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE IF NOT EXISTS doubleOptions(name TEXT PRIMARY KEY, value REAL, FOREIGN KEY(name) REFERENCES options(name) ON DELETE CASCADE ON UPDATE CASCADE);.
        /// </summary>
        internal static string mSQLCreateDoubleOptionsTable {
            get {
                return ResourceManager.GetString("mSQLCreateDoubleOptionsTable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE IF NOT EXISTS intOptions(name TEXT PRIMARY KEY, value INTEGER, FOREIGN KEY(name) REFERENCES options(name) ON DELETE CASCADE ON UPDATE CASCADE);.
        /// </summary>
        internal static string mSQLCreateIntOptionsTable {
            get {
                return ResourceManager.GetString("mSQLCreateIntOptionsTable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE IF NOT EXISTS stringOptions(name TEXT PRIMARY KEY, value TEXT, FOREIGN KEY(name) REFERENCES options(name) ON DELETE CASCADE ON UPDATE CASCADE);.
        /// </summary>
        internal static string mSQLCreateStrOptionsTable {
            get {
                return ResourceManager.GetString("mSQLCreateStrOptionsTable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to crossroadNodes.
        /// </summary>
        internal static string mSQLCrossroadNodesTableName {
            get {
                return ResourceManager.GetString("mSQLCrossroadNodesTableName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DELETE FROM {0}.
        /// </summary>
        internal static string mSQLDeleteAllRecords {
            get {
                return ResourceManager.GetString("mSQLDeleteAllRecords", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to doubleOptions.
        /// </summary>
        internal static string mSQLDoubleOptionsTableName {
            get {
                return ResourceManager.GetString("mSQLDoubleOptionsTableName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to intOptions.
        /// </summary>
        internal static string mSQLIntOptionsTableName {
            get {
                return ResourceManager.GetString("mSQLIntOptionsTableName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Data Source = {0}; Version = 3;.
        /// </summary>
        internal static string mSQLiteConnectionString {
            get {
                return ResourceManager.GetString("mSQLiteConnectionString", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to options.
        /// </summary>
        internal static string mSQLOptionsTableName {
            get {
                return ResourceManager.GetString("mSQLOptionsTableName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE IF NOT EXISTS buses (id INTEGER PRIMARY KEY, name TEXT, maxCapacity INTEGER, startTime INTEGER, alightingTimePerPassenger INTEGER, boardingTimePerPassenger INTEGER);.
        /// </summary>
        internal static string mSQLQueryCreateBusesTable {
            get {
                return ResourceManager.GetString("mSQLQueryCreateBusesTable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE IF NOT EXISTS options(name TEXT PRIMARY KEY, type INTEGER);.
        /// </summary>
        internal static string mSQLQueryCreateOptionsTable {
            get {
                return ResourceManager.GetString("mSQLQueryCreateOptionsTable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE IF NOT EXISTS routeNodes (id INTEGER PRIMARY KEY, name TEXT, position TEXT, type INTEGER);.
        /// </summary>
        internal static string mSQLQueryCreateRouteNodesTable {
            get {
                return ResourceManager.GetString("mSQLQueryCreateRouteNodesTable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DROP TABLE IF EXISTS {0}.
        /// </summary>
        internal static string mSQLQueryDropTable {
            get {
                return ResourceManager.GetString("mSQLQueryDropTable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT OR REPLACE INTO buses (id, name, maxCapacity, startTime, alightingTimePerPassenger, boardingTimePerPassenger) VALUES(@id, @name, @maxCapacity, @startTime, @alightingTimePerPassenger, @boardingTimePerPassenger).
        /// </summary>
        internal static string mSQLQueryInsertBus {
            get {
                return ResourceManager.GetString("mSQLQueryInsertBus", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT OR REPLACE INTO options(name, type) VALUES(@name, @type).
        /// </summary>
        internal static string mSQLQueryInsertOption {
            get {
                return ResourceManager.GetString("mSQLQueryInsertOption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT OR REPLACE INTO routeNodes (id, name, position, type) VALUES(@id, @name, @position, @type).
        /// </summary>
        internal static string mSQLQueryInsertRouteNode {
            get {
                return ResourceManager.GetString("mSQLQueryInsertRouteNode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT OR REPLACE INTO {0}(name, value) VALUES(@name, @value).
        /// </summary>
        internal static string mSQLQueryInsertTOption {
            get {
                return ResourceManager.GetString("mSQLQueryInsertTOption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to routeNodes.
        /// </summary>
        internal static string mSQLRouteNodesTableName {
            get {
                return ResourceManager.GetString("mSQLRouteNodesTableName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM {0}.
        /// </summary>
        internal static string mSQLSimpleSelectQuery {
            get {
                return ResourceManager.GetString("mSQLSimpleSelectQuery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to stringOptions.
        /// </summary>
        internal static string mSQLStrOptionsTableName {
            get {
                return ResourceManager.GetString("mSQLStrOptionsTableName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap mStartSimulationButtonImage {
            get {
                object obj = ResourceManager.GetObject("mStartSimulationButtonImage", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to startSimulationButton.
        /// </summary>
        internal static string mStartSimulationButtonName {
            get {
                return ResourceManager.GetString("mStartSimulationButtonName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to decl {{{0}    time : Time;{0}    beta : Matrix({1}, {2});{0}}}.
        /// </summary>
        internal static string mStationsDataHeaderTemplate {
            get {
                return ResourceManager.GetString("mStationsDataHeaderTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to case (&lt;please, type in a condition here&gt;) {{{0}    {1} = [{2}];{0}}}.
        /// </summary>
        internal static string mStationsEditorCaseTemplate {
            get {
                return ResourceManager.GetString("mStationsEditorCaseTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to default {{{0}    {1} = [{2}];{0}}}.
        /// </summary>
        internal static string mStationsEditorDefaultProgramTemplate {
            get {
                return ResourceManager.GetString("mStationsEditorDefaultProgramTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to График зависимости количества пассажиров на остановке от момента времени.
        /// </summary>
        internal static string mStationsPlotPassengersCountTitle {
            get {
                return ResourceManager.GetString("mStationsPlotPassengersCountTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Эпюра пассажиропотоков.
        /// </summary>
        internal static string mStationsPlotPassengersPowerTitle {
            get {
                return ResourceManager.GetString("mStationsPlotPassengersPowerTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap mStatisticsViewerButtonImage {
            get {
                object obj = ResourceManager.GetObject("mStatisticsViewerButtonImage", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Текущий режим: {0}.
        /// </summary>
        internal static string mStatusLabelMessage {
            get {
                return ResourceManager.GetString("mStatusLabelMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap mStopSimulationButtonImage {
            get {
                object obj = ResourceManager.GetObject("mStopSimulationButtonImage", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to stopSimulationButton.
        /// </summary>
        internal static string mStopSimulationButtonName {
            get {
                return ResourceManager.GetString("mStopSimulationButtonName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap mUndoButtonImage {
            get {
                object obj = ResourceManager.GetObject("mUndoButtonImage", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Внимание.
        /// </summary>
        internal static string mWarningMessageTitle {
            get {
                return ResourceManager.GetString("mWarningMessageTitle", resourceCulture);
            }
        }
    }
}
