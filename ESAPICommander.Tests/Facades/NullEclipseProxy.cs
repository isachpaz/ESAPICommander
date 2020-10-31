using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using ESAPICommander.Proxies;
using VMS.TPS.Common.Model;
using VMS.TPS.Common.Model.Types;

namespace ESAPICommander.Tests.Proxies
{
    public class NullEclipseProxy : IEsapiCalls
    {
        public void Dispose()
        {

        }

        public bool IsPatientAvailable(string piz)
        {
            return true;
        }

        public void OpenPatient(string piz)
        {

        }

        public void ClosePatient()
        {

        }

        public IEnumerable<ICourse> GetCourses()
        {
            return new List<ICourse>() { new xCourse() { Id = "C1" }, new xCourse() { Id = "C2" } };
        }

        public IEnumerable<IPlanSetup> GetPlanSetupsFor(ICourse course)
        {
            return new IPlanSetup[]{
                new xPlanSetup(){Id = "Plan-1"},
                new xPlanSetup(){Id = "Plan-2"},
            };
        }
    }

    public class xPlanSetup : IPlanSetup
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }

        public void DeleteTree()
        {
            throw new NotImplementedException();
        }

        public IApiModifyingMethodGuard GetESAPIClinicalModifyingMethodGuard(out string error)
        {
            throw new NotImplementedException();
        }

        public IApiModifyingMethodGuard GetESAPINonClinicalModifyingMethodGuard(out string error)
        {
            throw new NotImplementedException();
        }

        public bool IsUniqueId(string id)
        {
            throw new NotImplementedException();
        }

        public void SetUniqueId(string id)
        {
            throw new NotImplementedException();
        }

        public bool IsValidId(string id, StringBuilder errorHint)
        {
            throw new NotImplementedException();
        }

        public bool CheckIsValidIdForChild(string suggestedId, Type childType, StringBuilder errorHint)
        {
            throw new NotImplementedException();
        }

        public string GetUniqueIdForChild(string suggestedId, Type childType, bool ensureTailDigits)
        {
            throw new NotImplementedException();
        }

        public ITypeBasedIdValidator GetTypeBasedIdValidator()
        {
            throw new NotImplementedException();
        }

        public ITypeBasedIdGenerator GetTypeBasedIdGenerator()
        {
            throw new NotImplementedException();
        }

        public bool RefersToSameDataObject(IDataObject other)
        {
            throw new NotImplementedException();
        }

        public void ReleaseRelations()
        {
            throw new NotImplementedException();
        }

        public XmlSerializer GetXmlSerializer()
        {
            throw new NotImplementedException();
        }

        public IAdmin GetAdmin()
        {
            throw new NotImplementedException();
        }

        public IRenderer GetRenderer()
        {
            throw new NotImplementedException();
        }

        public long Key { get; }
        public string KeyAsDisplayString { get; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public UserInfo HistoryUser { get; }
        public string HistoryTaskName { get; }
        public DateTime HistoryDateTime { get; }
        public HistoryTimestamp HistoryTimestamp { get; }
        public string ToolTip { get; }
        public bool IsReadOnly { get; }
        public bool CanDelete { get; }
        public bool IsValid { get; }
        public bool IsDataModificationAllowed { get; }
        public IDVHData GetDVHCumulativeDataForStructure(IStructure structure, bool volumeAbsolute)
        {
            throw new NotImplementedException();
        }

        public IDVHData GetDVHDifferentialDataForStructure(IStructure structure, bool volumeAbsolute)
        {
            throw new NotImplementedException();
        }

        public IDVHData GetDVHCumulativeData(IStructure structure, DoseValuePresentation dosePresentation,
            VolumePresentation volumePresentation, double binWidth)
        {
            throw new NotImplementedException();
        }

        public DoseValue GetDoseAtVolume(IStructure structure, double volume, VolumePresentation volumePresentation,
            DoseValuePresentation requestedDosePresentation)
        {
            throw new NotImplementedException();
        }

        public double GetVolumeAtDose(IStructure structure, DoseValue dose, VolumePresentation requestedVolumePresentation)
        {
            throw new NotImplementedException();
        }

        public DateTime CreationDateTime { get; }
        public IPlanningItemDose Dose { get; }
        public IDataObjectReadOnlyCollection<IIsodose> Isodoses { get; }
        public DoseValuePresentation DoseValuePresentation { get; set; }
        public IImage Image { get; }
        public IDataObjectReadOnlyCollection<IPlanSetup> PlanSetups { get; }
        public IDataObjectReadOnlyCollection<IIsocenterGroup> IsocenterGroups { get; }
        public IStructure TargetStructure { get; }
        public IStructureSet StructureSet { get; }
        public IEnumerable<IStructure> StructuresSelectedForDvh { get; }
        public void SetToNoNormalization()
        {
            throw new NotImplementedException();
        }

        public bool ValidatePlanNormalizationValue(double data, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public void SetPrescription(int numberOfFractions, DoseValue dosePerFraction, double treatmentPercentage)
        {
            throw new NotImplementedException();
        }

        public bool SetTargetStructure(IStructure newTargetStructure, StringBuilder errorHint)
        {
            throw new NotImplementedException();
        }

        public DoseValue GetTargetDoseLevel(IStructure stru)
        {
            throw new NotImplementedException();
        }

        public IPlanSetup CreateCopyForIntermediateDoseCalculation()
        {
            throw new NotImplementedException();
        }

        public IObjectiveGroup CreateObjectiveGroup()
        {
            throw new NotImplementedException();
        }

        public IPlanUncertainties GetPlanUncertainties()
        {
            throw new NotImplementedException();
        }

        public void SetDVHEstimationStructuredInfo(string info)
        {
            throw new NotImplementedException();
        }

        public void ClearStructureMappingForStructure(IStructure structure)
        {
            throw new NotImplementedException();
        }

        public void ClearStructureMappingAll()
        {
            throw new NotImplementedException();
        }

        public void SetStructureMapping(IStructure structure, IDVHEstimationModelStructure modelStructure)
        {
            throw new NotImplementedException();
        }

        public void ClearDVHEstimates()
        {
            throw new NotImplementedException();
        }

        public IEstimatedDVH FindEstimatedDVHForStructure(DVHEstimateType type, IStructure structure)
        {
            throw new NotImplementedException();
        }

        public IDose GetDoseMatrix()
        {
            throw new NotImplementedException();
        }

        public List<Tuple<string, UserInfo, string, DateTime>> GetApprovalHistory()
        {
            throw new NotImplementedException();
        }

        public PlanSetupApprovalStatus StringToApprovalStatus(string str)
        {
            throw new NotImplementedException();
        }

        public bool PlanContainsLayersToBeDeleted()
        {
            throw new NotImplementedException();
        }

        public void RemoveLayersFromUnapprovedPlan()
        {
            throw new NotImplementedException();
        }

        public PlanValidationResult SetApprovalStatus(PlanSetupApprovalStatus newState, bool treatWarningsAsErrors,
            bool removeLayersFromUnapprovedPlan)
        {
            throw new NotImplementedException();
        }

        public PlanValidationResult SetApprovalStatus(PlanSetupApprovalStatus newState, IUser approver, bool treatWarningsAsErrors,
            bool removeLayersFromUnapprovedPlan)
        {
            throw new NotImplementedException();
        }

        public PlanValidationResult SetApprovalStatusDelegated(PlanSetupApprovalStatus newState, string userName,
            bool treatWarningsAsErrors, bool removeLayersFromUnapprovedPlan)
        {
            throw new NotImplementedException();
        }

        public bool HasRightToChangeState(PlanSetupApprovalStatus newState)
        {
            throw new NotImplementedException();
        }

        public bool IsPossibleNextState(PlanSetupApprovalStatus newState)
        {
            throw new NotImplementedException();
        }

        public PlanValidationResult CanChangeState(PlanSetupApprovalStatus newState)
        {
            throw new NotImplementedException();
        }

        public PlanValidationResult CanChangeState(PlanSetupApprovalStatus newState, IUser approver)
        {
            throw new NotImplementedException();
        }

        public PlanValidationResult ValidatePlan(PlanSetupApprovalStatus newState)
        {
            throw new NotImplementedException();
        }

        public string GetDoseGradientMeasureAsString(IStructure structure)
        {
            throw new NotImplementedException();
        }

        public string GetDoseConformalityIndexAsString(IStructure structure)
        {
            throw new NotImplementedException();
        }

        public double GetAbsConvFact()
        {
            throw new NotImplementedException();
        }

        public double GetRelConvFact()
        {
            throw new NotImplementedException();
        }

        public void UpdateActualTotalDoseForObjectives(IProtocolPhase phase)
        {
            throw new NotImplementedException();
        }

        public void GetProtocolAndPhase(ref IProtocol protocol, ref IProtocolPhase phase)
        {
            throw new NotImplementedException();
        }

        public bool SetProtocolAndPhase(IProtocol protocol, IProtocolPhase phase)
        {
            throw new NotImplementedException();
        }

        public void SetDoseConversion(IDose doseToSetConversionTo)
        {
            throw new NotImplementedException();
        }

        public void CheckPlanIntegrity()
        {
            throw new NotImplementedException();
        }

        public void CheckZeroDosePixels()
        {
            throw new NotImplementedException();
        }

        public void Open()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public IReferencePoint AddReferencePoint(IStructure structure, VVector? location, string id, string name)
        {
            throw new NotImplementedException();
        }

        public IPositionPresenter GetPositionPresenter(VVector pos)
        {
            throw new NotImplementedException();
        }

        public void CalculateTreatmentTimes(double factor)
        {
            throw new NotImplementedException();
        }

        public IPlanTemplate CreateArcSetTemplate(IIsocenterGroup isocenterGroup, string id)
        {
            throw new NotImplementedException();
        }

        public IDataObjectReadOnlyCollection<IBeam> InstantiateFieldsFromArcSetTemplate(IPlanTemplate planTemplate, VVector isocenterPosition,
            double coneSizeMM, IFieldCreationBusinessRules fieldCreationBusinessRules)
        {
            throw new NotImplementedException();
        }

        public IBeamPresenter CreatePresenterForNewBeam(IFieldCreationBusinessRules fcbr)
        {
            throw new NotImplementedException();
        }

        public IBeam CopyBeam(IBeam beam)
        {
            throw new NotImplementedException();
        }

        public void RefreshIsocenterGroups()
        {
            throw new NotImplementedException();
        }

        public void RemoveIsocenterGroup(IIsocenterGroup isocenterGroup)
        {
            throw new NotImplementedException();
        }

        public bool IsValidConePlan(out List<string> reasons)
        {
            throw new NotImplementedException();
        }

        public string GetCalculationModel(CalculationType calculationType)
        {
            throw new NotImplementedException();
        }

        public void SetCalculationModel(CalculationType calculationType, string model)
        {
            throw new NotImplementedException();
        }

        public void ClearCalculationModel(CalculationType calculationType)
        {
            throw new NotImplementedException();
        }

        public void ClearDVHEstimationLog()
        {
            throw new NotImplementedException();
        }

        public bool GetCalculationOptionsXmlAndXsd(string calculationModel, out string xmlStr, out string xsdPath)
        {
            throw new NotImplementedException();
        }

        public bool SetCalculationOptionsXml(string calculationModel, string xmlStr)
        {
            throw new NotImplementedException();
        }

        public bool GetCalculationOption(string calculationModel, string optionName, out string optionValue)
        {
            throw new NotImplementedException();
        }

        public bool SetCalculationOption(string calculationModel, string optionName, string optionValue)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetCalculationOptions(string calculationModel)
        {
            throw new NotImplementedException();
        }

        public void ResetCalculationArea()
        {
            throw new NotImplementedException();
        }

        public bool IsEntireBodyAndBolusesCoveredByCalculationArea()
        {
            throw new NotImplementedException();
        }

        public bool CreatePlanDoseMatrix()
        {
            throw new NotImplementedException();
        }

        public bool CanConvertToDemMachine(IExternalBeam newMachine, ref string warnings, ref string errors)
        {
            throw new NotImplementedException();
        }

        public void ConvertToDemMachine(IExternalBeam newMachine, ref string warnings, ref string errors, ref IPlanSetup newPlan)
        {
            throw new NotImplementedException();
        }

        public IExternalBeamConfiguration GetDefaultConfiguration(string machineId, string techniqueId, string energyModeId,
            int doseRateValue, string primaryFluenceModeId)
        {
            throw new NotImplementedException();
        }

        public bool CanOpenInESAPI(out string reasonIfNot)
        {
            throw new NotImplementedException();
        }

        public void SetOpenInESAPI()
        {
            throw new NotImplementedException();
        }

        public void UpdateConcurrencyState()
        {
            throw new NotImplementedException();
        }

        public IConcurrencyState CheckStructureSetStateInDB()
        {
            throw new NotImplementedException();
        }

        public IDisposable CreateObjectNotificationSuspendGuard()
        {
            throw new NotImplementedException();
        }

        public IDisposable CreateDoseRelevantChangeGuard()
        {
            throw new NotImplementedException();
        }

        public IDisposable CreateDVHEstimatePreserver()
        {
            throw new NotImplementedException();
        }

        public IDisposable CreateMcoStatePreserver()
        {
            throw new NotImplementedException();
        }

        public bool ValidatePlanDoseForIntermediateDose(bool IMRT, out string reasonIfNotAvailable)
        {
            throw new NotImplementedException();
        }

        public bool ValidateMlcConstraints(out string violations)
        {
            throw new NotImplementedException();
        }

        public bool GetMultiFieldOpt()
        {
            throw new NotImplementedException();
        }

        public bool IsProtonPlan()
        {
            throw new NotImplementedException();
        }

        public bool CanDoseBeReconstructed(IStructureSet structureSet, string treatmentMachineName, IReadOnlyList<IRecordedField> recordedFields,
            out ReasonWhyDoseCannotBeReconstructed reason)
        {
            throw new NotImplementedException();
        }

        public void ClearOptimizationResults(bool forceClearAll)
        {
            throw new NotImplementedException();
        }

        public IPlanSetup CreateTransientCopy(string planId, IReadOnlyList<IRecordedField> recordedFields)
        {
            throw new NotImplementedException();
        }

        public string GetDoseUnit()
        {
            throw new NotImplementedException();
        }

        public void UpdateProtocolPrescriptionActualValues()
        {
            throw new NotImplementedException();
        }

        public void UpdateProtocolMeasureActualValues()
        {
            throw new NotImplementedException();
        }

        public string UID { get; }
        public PlanType PlanType { get; }
        public string TreatmentType { get; }
        public bool IsTreated { get; }
        public IEnumerable<IApplicationScriptLog> ApplicationScriptLogs { get; }
        public string CreationUserName { get; }
        public UserInfo CreationUser { get; }
        public string Status { get; }
        public DateTime StatusDate { get; }
        public UserInfo StatusUser { get; }
        public string PlanNormalizationMethod { get; }
        public VVector PlanNormalizationPoint { get; }
        public bool IsNormalizationNoNormalization { get; }
        public bool IsExposedToIT { get; }
        public double PlanNormalizationFactor { get; }
        public double PlanNormalizationValue { get; set; }
        public string PlanIntent { get; }
        public IPlanSetup VerifiedPlan { get; }
        public string ProtocolID { get; }
        public string ProtocolPhaseID { get; }
        public int? NumberOfFractions { get; set; }
        public DoseValue PrescribedDosePerFraction { get; set; }
        public DoseValue DosePerFraction { get; set; }
        public DoseValue DosePerFractionInPrimaryRefPoint { get; }
        public DoseValue PlannedDosePerFraction { get; }
        public double FractionStartDelay { get; }
        public IFractionationPresenter FractionationPresenter { get; }
        public IEnumerable<QualityMetricType> QualityMetricTypes { get; }
        public string TargetVolumeID { get; }
        public ICourse Course { get; }
        public ISeries Series { get; }
        public string SeriesUID { get; }
        public bool IsHyperArc { get; }
        public IProtocolPhase ProtocolPhase { get; }
        public IEnumerable<IStructureDoseObjectives> StructureDoseObjectivesOfClinicalProtocolPhase { get; }
        public int NumberOfClinicalProtocolPlanDoseObjectives { get; }
        public IObjectiveGroup ObjectiveGroup { get; set; }
        public IObjectiveGroupDefaults ObjectiveGroupDefaultValues { get; }
        public IOptimizationSetup OptimizationSetup { get; }
        public IEnumerable<IPlanUncertainty> PlanUncertainties { get; }
        public Guid DVHEstimationModelGuid { get; set; }
        public IDataObjectReadOnlyCollection<IEstimatedDVH> DVHEstimates { get; }
        public string DVHEstimationStructuredInfo { get; }
        public IDataObjectReadOnlyCollection<IPlanSetupStructureMapping> DVHEstimateStructureMappings { get; }
        public bool IsDoseValid { get; }
        public PlanSetupApprovalStatus ApprovalStatus { get; }
        public string ApprovalStatusAsString { get; }
        public string PlanningApprovalDate { get; }
        public string PlanningApprover { get; }
        public string PlanningApproverDisplayName { get; }
        public string TreatmentApprovalDate { get; }
        public string TreatmentApprover { get; }
        public string TreatmentApproverDisplayName { get; }
        public IPlanSetup PredecessorPlan { get; }
        public double PrescribedPercentage { get; set; }
        public double TreatmentPercentage { get; set; }
        public DoseValue TotalPrescribedDose { get; }
        public DoseValue TotalDose { get; }
        public bool UseGating { get; set; }
        public bool IsAbsDosePossible { get; }
        public IReferencePoint PrimaryReferencePoint { get; }
        public IDataObjectReadOnlyCollection<IReferencePoint> ReferencePoints { get; }
        public PatientOrientation TreatmentOrientation { get; }
        public double SkinFlashMargin { get; }
        public string FieldAlignmentRules { get; }
        public IDataObjectReadOnlyCollection<IBeam> Beams { get; }
        public IEnumerable<IBeam> TreatmentBeams { get; }
        public IEnumerable<IBeam> NonImagingTreatmentBeams { get; }
        public IExternalBeamConfiguration NewBeamConfiguration { get; set; }
        public int IsocenterPositionCount { get; }
        public bool IsConePlan { get; }
        public bool IsIrregPlan { get; }
        public string ElectronCalculationModel { get; }
        public Dictionary<string, string> ElectronCalculationOptions { get; }
        public string PhotonCalculationModel { get; }
        public Dictionary<string, string> PhotonCalculationOptions { get; }
        public string ProtonCalculationModel { get; }
        public Dictionary<string, string> ProtonCalculationOptions { get; }
        public DoseValue SRSGlobalDoseMax { get; }
        public IConeCalculator ConeCalculator { get; }
        public IDataObjectReadOnlyCollection<IApplicator> ConfiguredCones { get; }
        public IDataObjectReadOnlyCollection<IExternalBeam> DemMachines { get; }
        public IRTPrescription RTPrescription { get; }
        public IConcurrencyState ConcurrencyState { get; }
        public IDataObjectReadOnlyCollection<IPlanTreatmentSession> TreatmentSessions { get; }
        public event OnCalculationRelevantChangeHandler OnCalculationRelevantChange;
        public event OnPrescriptionRelevantChangeHandler OnPrescriptionRelevantChange;
    }
    public class xCourse : ICourse
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }

        public void DeleteTree()
        {
            throw new NotImplementedException();
        }

        public IApiModifyingMethodGuard GetESAPIClinicalModifyingMethodGuard(out string error)
        {
            throw new NotImplementedException();
        }

        public IApiModifyingMethodGuard GetESAPINonClinicalModifyingMethodGuard(out string error)
        {
            throw new NotImplementedException();
        }

        public bool IsUniqueId(string id)
        {
            throw new NotImplementedException();
        }

        public void SetUniqueId(string id)
        {
            throw new NotImplementedException();
        }

        public bool IsValidId(string id, StringBuilder errorHint)
        {
            throw new NotImplementedException();
        }

        public bool CheckIsValidIdForChild(string suggestedId, Type childType, StringBuilder errorHint)
        {
            throw new NotImplementedException();
        }

        public string GetUniqueIdForChild(string suggestedId, Type childType, bool ensureTailDigits)
        {
            throw new NotImplementedException();
        }

        public ITypeBasedIdValidator GetTypeBasedIdValidator()
        {
            throw new NotImplementedException();
        }

        public ITypeBasedIdGenerator GetTypeBasedIdGenerator()
        {
            throw new NotImplementedException();
        }

        public bool RefersToSameDataObject(IDataObject other)
        {
            throw new NotImplementedException();
        }

        public void ReleaseRelations()
        {
            throw new NotImplementedException();
        }

        public XmlSerializer GetXmlSerializer()
        {
            throw new NotImplementedException();
        }

        public IAdmin GetAdmin()
        {
            throw new NotImplementedException();
        }

        public IRenderer GetRenderer()
        {
            throw new NotImplementedException();
        }

        public long Key { get; }
        public string KeyAsDisplayString { get; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public UserInfo HistoryUser { get; }
        public string HistoryTaskName { get; }
        public DateTime HistoryDateTime { get; }
        public HistoryTimestamp HistoryTimestamp { get; }
        public string ToolTip { get; }
        public bool IsReadOnly { get; }
        public bool CanDelete { get; }
        public bool IsValid { get; }
        public bool IsDataModificationAllowed { get; }
        public IProtocol AddProtocol(IProtocolPreview preview)
        {
            throw new NotImplementedException();
        }

        public void RemoveProtocol(IProtocol protocol)
        {
            throw new NotImplementedException();
        }

        public IExternalPlanSetup AddExternalPlanSetup(IImage image, IReferencePointSelector referencePointSelection)
        {
            throw new NotImplementedException();
        }

        public IExternalPlanSetup AddExternalPlanSetup(IStructureSet structureSet)
        {
            throw new NotImplementedException();
        }

        public IExternalPlanSetup AddExternalPlanSetupAsVerificationPlan(IStructureSet structureSet, IExternalPlanSetup verifiedPlan)
        {
            throw new NotImplementedException();
        }

        public IProtonPlanSetup AddProtonPlanSetup(IImage image, string patientSupportDeviceId,
            IReferencePointSelector referencePointSelection)
        {
            throw new NotImplementedException();
        }

        public IProtonPlanSetup AddProtonPlanSetup(IStructureSet structureSet, string patientSupportDeviceId)
        {
            throw new NotImplementedException();
        }

        public IProtonPlanSetup AddProtonPlanSetupAsVerificationPlan(IStructureSet structureSet, string patientSupportDeviceId,
            IProtonPlanSetup verifiedPlan)
        {
            throw new NotImplementedException();
        }

        public bool CanAddPlanSetup(IStructureSet structureSet)
        {
            throw new NotImplementedException();
        }

        public IPlanSetup CopyPlanSetup(IPlanSetup sourcePlan, StringBuilder outputDiagnostics)
        {
            throw new NotImplementedException();
        }

        public IPlanSetup CopyPlanSetup(IPlanSetup sourcePlan, IImage targetImage, StringBuilder outputDiagnostics)
        {
            throw new NotImplementedException();
        }

        public IPlanSetup CopyPlanSetup(IPlanSetup sourcePlan, IImage targetImage, IRegistration registration,
            StringBuilder outputDiagnostics)
        {
            throw new NotImplementedException();
        }

        public IPlanSetup CopyPlanSetup(IPlanSetup sourcePlan)
        {
            throw new NotImplementedException();
        }

        public IPlanSetup CopyPlanSetup(IPlanSetup sourcePlan, IStructureSet structureset, StringBuilder outputDiagnostics)
        {
            throw new NotImplementedException();
        }

        public IPlanSetup CreateTransientCopyForDoseReconstructionUsingStructureSetFromSameFOR(IPlanSetup sourcePlan,
            IStructureSet structureset, string newPlanId, string treatmentMachineName, IReadOnlyList<IRecordedField> recordedFields)
        {
            throw new NotImplementedException();
        }

        public void RemovePlanSetup(IPlanSetup planSetup)
        {
            throw new NotImplementedException();
        }

        public bool CanRemovePlanSetup(IPlanSetup planSetup)
        {
            throw new NotImplementedException();
        }

        public string LoadDartStorageExtension()
        {
            throw new NotImplementedException();
        }

        public void StoreDartStorageExtension(string data)
        {
            throw new NotImplementedException();
        }

        public IPlanningItem CreateSumOfPlans(IEnumerable<IPlanningItem> planningItems, IImage image)
        {
            throw new NotImplementedException();
        }

        public string Intent { get; }
        public string LocalizedCourseIntent { get; }
        public DateTime StartDateTime { get; }
        public DateTime CompletedDateTime { get; }
        public string CompletedByUserName { get; }
        public IPatient Patient { get; }
        public IDataObjectReadOnlyCollection<IPlanSetup> PlanSetups { get; }
        public IDataObjectReadOnlyCollection<IPlanSum> PlanSums { get; }
        public IDataObjectReadOnlyCollection<IProtocol> Protocols { get; }
        public IDataObjectReadOnlyCollection<ITreatmentSession> TreatmentSessions { get; }
        public IDataObjectReadOnlyCollection<IDiagnosis> Diagnoses { get; }
        public IDataObjectReadOnlyCollection<ITreatmentPhase> TreatmentPhases { get; }
        public ITreatmentSession FirstActiveTreatmentSession { get; }
    }
}