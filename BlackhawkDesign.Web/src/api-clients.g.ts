import * as $metadata from './metadata.g'
import * as $models from './models.g'
import { AxiosClient, ModelApiClient, ServiceApiClient, ItemResult, ListResult } from 'coalesce-vue/lib/api-client'
import { AxiosPromise, AxiosResponse, AxiosRequestConfig } from 'axios'

export class ApplicationApiClient extends ModelApiClient<$models.Application> {
  constructor() { super($metadata.Application) }
  public uploadAttachment(id: string, file: File | null, $config?: AxiosRequestConfig): AxiosPromise<ItemResult<void>> {
    const $method = this.$metadata.methods.uploadAttachment
    const $params =  {
      id,
      file,
    }
    return this.$invoke($method, $params, $config)
  }
  
  public downloadAttachment(id: string, etag: string | null, $config?: AxiosRequestConfig): AxiosPromise<ItemResult<File>> {
    const $method = this.$metadata.methods.downloadAttachment
    const $params =  {
      id,
      etag,
    }
    return this.$invoke($method, $params, $config)
  }
  
}


export class JobApiClient extends ModelApiClient<$models.Job> {
  constructor() { super($metadata.Job) }
}


export class JobApplicationApiClient extends ModelApiClient<$models.JobApplication> {
  constructor() { super($metadata.JobApplication) }
}


