<template>
  <v-card class="mx-auto" max-width="500">
    <v-card-title class="text-h6 font-weight-regular justify-space-between">
      <span>{{ currentTitle }}</span>
      <v-avatar align="end" color="primary" size="32" v-text="step"></v-avatar>
    </v-card-title>

    <v-window v-model="step">
      <v-window-item :value="1">
        <v-card-text>
          <c-input
            :model="budget"
            for="firstName"
            autofocus
            @keyup.enter="save"
            label="First name..."
            placeholder="John"
          />
          <c-input
            :model="budget"
            for="lastName"
            @keyup.enter="save"
            label="Last name..."
            placeholder="Doe"
          />

          <span class="text-caption text-grey-darken-1">
            This is the email you will use to login to your Blackhawk Design
            account
          </span>
        </v-card-text>
      </v-window-item>

      <v-window-item :value="2">
        <v-card-text>
          <c-input
            :model="budget"
            for="email"
            @keyup.enter="save"
            label="Email"
            placeholder="john@gmail.com"
          />
          <c-input
            :model="budget"
            for="phoneNumber"
            label="Phone"
            placeholder="Phone"
            @keyup.enter="save"
          />

          <span class="text-caption text-grey-darken-1">
            Enter contact information, so we can get ahold of you.
          </span>
        </v-card-text>
      </v-window-item>

      <v-window-item :value="3">
        <div class="pa-4 text-center">
          <c-input
            :model="budget.uploadAttachment"
            for="file"
            variant="solo"
          ></c-input>
          <c-select-many-to-many
            :model="budget"
            for="jobApplied"
            dense
            outlined
            label="Applying For"
          />
          <c-input
            :model="budget"
            for="coverLetter"
            @keyup.enter="save"
            label="Cover Letter (Optional)"
            placeholder=""
          />
          <span class="text-caption text-grey"
            >Resume is optional please click submit and you're done!</span
          >
        </div>
      </v-window-item>

      <v-window-item :value="4">
        <div class="pa-4 text-center">
          <v-img
            class="mb-4"
            contain
            height="128"
            src="../assets/logo.png"
          ></v-img>
          <h3 class="text-h6 font-weight-light mb-2">
            Thanks for applying to Blackhawk Design
          </h3>
          <span class="text-caption text-grey"
            >Thanks for applying it can take up to several business days to
            review your application!</span
          >
        </div>
      </v-window-item>
    </v-window>

    <v-divider></v-divider>

    <v-card-actions>
      <v-btn v-if="step > 1 && step <= 3" variant="text" @click="step--"> Back </v-btn>
      <v-spacer></v-spacer>
      <v-btn v-if="step < 3" color="primary" variant="flat" @click="step++">
        Next
      </v-btn>
      <v-btn v-if="step == 3" color="primary" variant="flat" @click="step++">
        Submit
      </v-btn>
    </v-card-actions>
  </v-card>
</template>

<script setup lang="ts">
import { defineProps, defineEmits, computed } from "vue";
import { ApplicationViewModel, JobListViewModel } from "@/viewmodels.g";
const jobList = new JobListViewModel();
jobList.$load();

const props = defineProps<{
  budget: ApplicationViewModel;
}>();

const newApp = computed(() => !props.budget.normalizedName);

const emit = defineEmits<{
  (e: "saved"): void;
}>();

async function save() {
  if (props.budget.firstName && props.budget.lastName) {
    props.budget.normalizedName =
      props.budget.firstName + " " + props.budget.lastName;

    await props.budget.$save();
    emit("saved");
    alert("Submitted!");
  }
}

async function upload() {
  await props.budget.uploadAttachment.invokeWithArgs();
}
let hasSaved: boolean = false;
function handleSave() {
  if (!hasSaved) {
    {
      hasSaved = true;
      save();
    }
  }
}

const step = ref(1);
// watch works directly on a ref
watch(step, async (newStep, oldStep) => {
  console.log(newStep);
  console.log(oldStep);
  if (oldStep == 3 && newStep == 4) {
    await save();
    await upload();
  }
});
const currentTitle = computed(() => {
  switch (step.value) {
    case 1:
      return "Application";
    case 2:
      if (props.budget.firstName && props.budget.lastName) {
        {
          return "Contact Information";
        }
      } else {
        {
          step.value--;
          return "Application";
        }
      }
    case 3:
      if (props.budget.email && props.budget.phoneNumber) {
        {
          handleSave();
          return "Upload your resume!";
        }
      } else {
        {
          step.value--;
          return "Contact Information";
        }
      }
    default:
      return "Application Created";
  }
});
</script>
