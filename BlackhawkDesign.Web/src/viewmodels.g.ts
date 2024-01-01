import * as $metadata from './metadata.g'
import * as $models from './models.g'
import * as $apiClients from './api-clients.g'
import { ViewModel, ListViewModel, ServiceViewModel, DeepPartial, defineProps } from 'coalesce-vue/lib/viewmodel'

export interface ApplicationViewModel extends $models.Application {
  normalizedName: string | null;
  firstName: string | null;
  lastName: string | null;
  email: string | null;
  phoneNumber: string | null;
  jobApplied: JobApplicationViewModel[] | null;
  coverLetter: string | null;
  applied: Date | null;
  attachmentName: string | null;
  attachmentSize: number | null;
  attachmentType: string | null;
  attachmentHash: string | null;
}
export class ApplicationViewModel extends ViewModel<$models.Application, $apiClients.ApplicationApiClient, string> implements $models.Application  {
  
  
  public addToJobApplied() {
    return this.$addChild('jobApplied') as JobApplicationViewModel
  }
  
  get jobs(): ReadonlyArray<JobViewModel> {
    return (this.jobApplied || []).map($ => $.job!).filter($ => $)
  }
  
  public get uploadAttachment() {
    const uploadAttachment = this.$apiClient.$makeCaller(
      this.$metadata.methods.uploadAttachment,
      (c, file: File | null) => c.uploadAttachment(this.$primaryKey, file),
      () => ({file: null as File | null, }),
      (c, args) => c.uploadAttachment(this.$primaryKey, args.file))
    
    Object.defineProperty(this, 'uploadAttachment', {value: uploadAttachment});
    return uploadAttachment
  }
  
  public get downloadAttachment() {
    const downloadAttachment = this.$apiClient.$makeCaller(
      this.$metadata.methods.downloadAttachment,
      (c) => c.downloadAttachment(this.$primaryKey, this.attachmentHash),
      () => ({}),
      (c, args) => c.downloadAttachment(this.$primaryKey, this.attachmentHash))
    
    Object.defineProperty(this, 'downloadAttachment', {value: downloadAttachment});
    return downloadAttachment
  }
  
  constructor(initialData?: DeepPartial<$models.Application> | null) {
    super($metadata.Application, new $apiClients.ApplicationApiClient(), initialData)
  }
}
defineProps(ApplicationViewModel, $metadata.Application)

export class ApplicationListViewModel extends ListViewModel<$models.Application, $apiClients.ApplicationApiClient, ApplicationViewModel> {
  
  constructor() {
    super($metadata.Application, new $apiClients.ApplicationApiClient())
  }
}


export interface JobViewModel extends $models.Job {
  jobName: string | null;
  jobImage: string | null;
  jobDesc: string | null;
  jobBenefit: string | null;
  qualifications: string | null;
}
export class JobViewModel extends ViewModel<$models.Job, $apiClients.JobApiClient, string> implements $models.Job  {
  
  constructor(initialData?: DeepPartial<$models.Job> | null) {
    super($metadata.Job, new $apiClients.JobApiClient(), initialData)
  }
}
defineProps(JobViewModel, $metadata.Job)

export class JobListViewModel extends ListViewModel<$models.Job, $apiClients.JobApiClient, JobViewModel> {
  
  constructor() {
    super($metadata.Job, new $apiClients.JobApiClient())
  }
}


export interface JobApplicationViewModel extends $models.JobApplication {
  jobApplicationId: number | null;
  applicationId: string | null;
  application: ApplicationViewModel | null;
  jobId: string | null;
  job: JobViewModel | null;
}
export class JobApplicationViewModel extends ViewModel<$models.JobApplication, $apiClients.JobApplicationApiClient, number> implements $models.JobApplication  {
  
  constructor(initialData?: DeepPartial<$models.JobApplication> | null) {
    super($metadata.JobApplication, new $apiClients.JobApplicationApiClient(), initialData)
  }
}
defineProps(JobApplicationViewModel, $metadata.JobApplication)

export class JobApplicationListViewModel extends ListViewModel<$models.JobApplication, $apiClients.JobApplicationApiClient, JobApplicationViewModel> {
  
  constructor() {
    super($metadata.JobApplication, new $apiClients.JobApplicationApiClient())
  }
}


const viewModelTypeLookup = ViewModel.typeLookup = {
  Application: ApplicationViewModel,
  Job: JobViewModel,
  JobApplication: JobApplicationViewModel,
}
const listViewModelTypeLookup = ListViewModel.typeLookup = {
  Application: ApplicationListViewModel,
  Job: JobListViewModel,
  JobApplication: JobApplicationListViewModel,
}
const serviceViewModelTypeLookup = ServiceViewModel.typeLookup = {
}

