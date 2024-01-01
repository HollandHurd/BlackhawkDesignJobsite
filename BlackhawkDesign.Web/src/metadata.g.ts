import {
  Domain, getEnumMeta, solidify, ModelType, ObjectType,
  PrimitiveProperty, ForeignKeyProperty, PrimaryKeyProperty,
  ModelCollectionNavigationProperty, ModelReferenceNavigationProperty,
  HiddenAreas, BehaviorFlags
} from 'coalesce-vue/lib/metadata'


const domain: Domain = { enums: {}, types: {}, services: {} }
export const Application = domain.types.Application = {
  name: "Application",
  displayName: "Application",
  get displayProp() { return this.props.normalizedName }, 
  type: "model",
  controllerRoute: "Application",
  get keyProp() { return this.props.normalizedName }, 
  behaviorFlags: 7 as BehaviorFlags,
  props: {
    normalizedName: {
      name: "normalizedName",
      displayName: "Normalized Name",
      type: "string",
      role: "primaryKey",
      createOnly: true,
      rules: {
        required: val => (val != null && val !== '') || "Normalized Name is required.",
      }
    },
    firstName: {
      name: "firstName",
      displayName: "First Name",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "First Name is required.",
      }
    },
    lastName: {
      name: "lastName",
      displayName: "Last Name",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Last Name is required.",
      }
    },
    email: {
      name: "email",
      displayName: "Email",
      type: "string",
      subtype: "email",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Email is required.",
        email: val => !val || /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<> ()\[\]\\.,;:\s@"]+)*)|(".+ "))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(val.trim()) || "Email must be a valid email address.",
      }
    },
    phoneNumber: {
      name: "phoneNumber",
      displayName: "Phone Number",
      type: "string",
      subtype: "tel",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Phone Number is required.",
        phone: val => !val || /^(\+\s?)?((?<!\+.*)\(\+?\d+([\s\-\.]?\d+)?\)|\d+)([\s\-\.]?(\(\d+([\s\-\.]?\d+)?\)|\d+))*(\s?(x|ext\.?)\s?\d+)?$/.test(val.replace(/\s+/g, '')) || "Phone Number must be a valid phone number.",
      }
    },
    jobApplied: {
      name: "jobApplied",
      displayName: "Job Applied",
      type: "collection",
      itemType: {
        name: "$collectionItem",
        displayName: "",
        role: "value",
        type: "model",
        get typeDef() { return (domain.types.JobApplication as ModelType) },
      },
      role: "collectionNavigation",
      get foreignKey() { return (domain.types.JobApplication as ModelType).props.applicationId as ForeignKeyProperty },
      get inverseNavigation() { return (domain.types.JobApplication as ModelType).props.application as ModelReferenceNavigationProperty },
      manyToMany: {
        name: "jobs",
        displayName: "Jobs",
        get typeDef() { return (domain.types.Job as ModelType) },
        get farForeignKey() { return (domain.types.JobApplication as ModelType).props.jobId as ForeignKeyProperty },
        get farNavigationProp() { return (domain.types.JobApplication as ModelType).props.job as ModelReferenceNavigationProperty },
        get nearForeignKey() { return (domain.types.JobApplication as ModelType).props.applicationId as ForeignKeyProperty },
        get nearNavigationProp() { return (domain.types.JobApplication as ModelType).props.application as ModelReferenceNavigationProperty },
      },
      dontSerialize: true,
    },
    coverLetter: {
      name: "coverLetter",
      displayName: "Cover Letter",
      type: "string",
      role: "value",
    },
    applied: {
      name: "applied",
      displayName: "Applied",
      type: "date",
      dateKind: "datetime",
      role: "value",
      dontSerialize: true,
    },
    attachmentName: {
      name: "attachmentName",
      displayName: "Attachment Name",
      type: "string",
      role: "value",
      dontSerialize: true,
    },
    attachmentSize: {
      name: "attachmentSize",
      displayName: "Attachment Size",
      type: "number",
      role: "value",
      dontSerialize: true,
    },
    attachmentType: {
      name: "attachmentType",
      displayName: "Attachment Type",
      type: "string",
      role: "value",
      dontSerialize: true,
    },
    attachmentHash: {
      name: "attachmentHash",
      displayName: "Attachment Hash",
      type: "binary",
      base64: true,
      role: "value",
      dontSerialize: true,
    },
  },
  methods: {
    uploadAttachment: {
      name: "uploadAttachment",
      displayName: "Upload Attachment",
      transportType: "item",
      httpMethod: "POST",
      params: {
        id: {
          name: "id",
          displayName: "Primary Key",
          type: "string",
          role: "value",
          get source() { return (domain.types.Application as ModelType).props.normalizedName },
        },
        file: {
          name: "file",
          displayName: "File",
          type: "file",
          role: "value",
        },
      },
      return: {
        name: "$return",
        displayName: "Result",
        type: "void",
        role: "value",
      },
    },
    downloadAttachment: {
      name: "downloadAttachment",
      displayName: "Download Attachment",
      transportType: "item",
      httpMethod: "GET",
      params: {
        id: {
          name: "id",
          displayName: "Primary Key",
          type: "string",
          role: "value",
          get source() { return (domain.types.Application as ModelType).props.normalizedName },
        },
        etag: {
          name: "etag",
          displayName: "Etag",
          type: "binary",
          role: "value",
          get source() { return (domain.types.Application as ModelType).props.attachmentHash },
        },
      },
      return: {
        name: "$return",
        displayName: "Result",
        type: "file",
        role: "value",
      },
    },
  },
  dataSources: {
  },
}
export const Job = domain.types.Job = {
  name: "Job",
  displayName: "Job",
  get displayProp() { return this.props.jobName }, 
  type: "model",
  controllerRoute: "Job",
  get keyProp() { return this.props.jobName }, 
  behaviorFlags: 7 as BehaviorFlags,
  props: {
    jobName: {
      name: "jobName",
      displayName: "Job Name",
      type: "string",
      role: "primaryKey",
      createOnly: true,
      rules: {
        required: val => (val != null && val !== '') || "Job Name is required.",
      }
    },
    jobImage: {
      name: "jobImage",
      displayName: "Job Image",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Job Image is required.",
      }
    },
    jobDesc: {
      name: "jobDesc",
      displayName: "Job Desc",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Job Desc is required.",
      }
    },
    jobBenefit: {
      name: "jobBenefit",
      displayName: "Job Benefit",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Job Benefit is required.",
      }
    },
    qualifications: {
      name: "qualifications",
      displayName: "Qualifications",
      type: "string",
      role: "value",
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const JobApplication = domain.types.JobApplication = {
  name: "JobApplication",
  displayName: "Job Application",
  get displayProp() { return this.props.jobApplicationId }, 
  type: "model",
  controllerRoute: "JobApplication",
  get keyProp() { return this.props.jobApplicationId }, 
  behaviorFlags: 7 as BehaviorFlags,
  props: {
    jobApplicationId: {
      name: "jobApplicationId",
      displayName: "Job Application Id",
      type: "number",
      role: "primaryKey",
      hidden: 3 as HiddenAreas,
    },
    applicationId: {
      name: "applicationId",
      displayName: "Application Id",
      type: "string",
      role: "foreignKey",
      get principalKey() { return (domain.types.Application as ModelType).props.normalizedName as PrimaryKeyProperty },
      get principalType() { return (domain.types.Application as ModelType) },
      get navigationProp() { return (domain.types.JobApplication as ModelType).props.application as ModelReferenceNavigationProperty },
      hidden: 3 as HiddenAreas,
    },
    application: {
      name: "application",
      displayName: "Application",
      type: "model",
      get typeDef() { return (domain.types.Application as ModelType) },
      role: "referenceNavigation",
      get foreignKey() { return (domain.types.JobApplication as ModelType).props.applicationId as ForeignKeyProperty },
      get principalKey() { return (domain.types.Application as ModelType).props.normalizedName as PrimaryKeyProperty },
      get inverseNavigation() { return (domain.types.Application as ModelType).props.jobApplied as ModelCollectionNavigationProperty },
      dontSerialize: true,
    },
    jobId: {
      name: "jobId",
      displayName: "Job Id",
      type: "string",
      role: "foreignKey",
      get principalKey() { return (domain.types.Job as ModelType).props.jobName as PrimaryKeyProperty },
      get principalType() { return (domain.types.Job as ModelType) },
      get navigationProp() { return (domain.types.JobApplication as ModelType).props.job as ModelReferenceNavigationProperty },
      hidden: 3 as HiddenAreas,
    },
    job: {
      name: "job",
      displayName: "Job",
      type: "model",
      get typeDef() { return (domain.types.Job as ModelType) },
      role: "referenceNavigation",
      get foreignKey() { return (domain.types.JobApplication as ModelType).props.jobId as ForeignKeyProperty },
      get principalKey() { return (domain.types.Job as ModelType).props.jobName as PrimaryKeyProperty },
      dontSerialize: true,
    },
  },
  methods: {
  },
  dataSources: {
  },
}

interface AppDomain extends Domain {
  enums: {
  }
  types: {
    Application: typeof Application
    Job: typeof Job
    JobApplication: typeof JobApplication
  }
  services: {
  }
}

solidify(domain)

export default domain as unknown as AppDomain
