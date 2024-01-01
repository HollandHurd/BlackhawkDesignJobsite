import * as metadata from './metadata.g'
import { Model, DataSource, convertToModel, mapToModel } from 'coalesce-vue/lib/model'

export interface Application extends Model<typeof metadata.Application> {
  normalizedName: string | null
  firstName: string | null
  lastName: string | null
  email: string | null
  phoneNumber: string | null
  jobApplied: JobApplication[] | null
  coverLetter: string | null
  applied: Date | null
  attachmentName: string | null
  attachmentSize: number | null
  attachmentType: string | null
  attachmentHash: string | null
}
export class Application {
  
  /** Mutates the input object and its descendents into a valid Application implementation. */
  static convert(data?: Partial<Application>): Application {
    return convertToModel(data || {}, metadata.Application) 
  }
  
  /** Maps the input object and its descendents to a new, valid Application implementation. */
  static map(data?: Partial<Application>): Application {
    return mapToModel(data || {}, metadata.Application) 
  }
  
  /** Instantiate a new Application, optionally basing it on the given data. */
  constructor(data?: Partial<Application> | {[k: string]: any}) {
    Object.assign(this, Application.map(data || {}));
  }
}


export interface Job extends Model<typeof metadata.Job> {
  jobName: string | null
  jobImage: string | null
  jobDesc: string | null
  jobBenefit: string | null
  qualifications: string | null
}
export class Job {
  
  /** Mutates the input object and its descendents into a valid Job implementation. */
  static convert(data?: Partial<Job>): Job {
    return convertToModel(data || {}, metadata.Job) 
  }
  
  /** Maps the input object and its descendents to a new, valid Job implementation. */
  static map(data?: Partial<Job>): Job {
    return mapToModel(data || {}, metadata.Job) 
  }
  
  /** Instantiate a new Job, optionally basing it on the given data. */
  constructor(data?: Partial<Job> | {[k: string]: any}) {
    Object.assign(this, Job.map(data || {}));
  }
}


export interface JobApplication extends Model<typeof metadata.JobApplication> {
  jobApplicationId: number | null
  applicationId: string | null
  application: Application | null
  jobId: string | null
  job: Job | null
}
export class JobApplication {
  
  /** Mutates the input object and its descendents into a valid JobApplication implementation. */
  static convert(data?: Partial<JobApplication>): JobApplication {
    return convertToModel(data || {}, metadata.JobApplication) 
  }
  
  /** Maps the input object and its descendents to a new, valid JobApplication implementation. */
  static map(data?: Partial<JobApplication>): JobApplication {
    return mapToModel(data || {}, metadata.JobApplication) 
  }
  
  /** Instantiate a new JobApplication, optionally basing it on the given data. */
  constructor(data?: Partial<JobApplication> | {[k: string]: any}) {
    Object.assign(this, JobApplication.map(data || {}));
  }
}


