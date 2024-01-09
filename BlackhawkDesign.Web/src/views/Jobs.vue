<template>
  <v-row align="center" justify="center">
    <div v-for="item of jobList.$items">
    <v-col cols="auto">
      
        
      
      <v-card
    class="mx-auto"
    max-width="400"
  >
    <v-img
      :src=item.jobImage
      height="200px"
      cover
    ></v-img>

    <v-card-title>
      {{ item.jobName }}
    </v-card-title>

    <v-card-subtitle>
      Description: {{ item.jobDesc }}
    </v-card-subtitle>

    <v-card-actions>
      <v-btn
        color="primary"
        variant="tonal"
        href="/apply"
      >
        Apply
      </v-btn>

      <v-spacer></v-spacer>
      
      <v-btn
        :icon="show ? 'fa fa-angles-up' : 'fa fa-angles-down'"
        @click="show = !show"
      ></v-btn>
    </v-card-actions>

    <v-expand-transition>
      <div v-show="show">
        <v-divider></v-divider>

        <v-card-text>
          {{ item.jobBenefit }}
        </v-card-text>
      </div>
    </v-expand-transition>
  </v-card>
      
    </v-col>
  </div>
  </v-row>
  <Footer></Footer>
</template>

<script setup>
import { ref, watch, onMounted } from "vue";
import { JobViewModel, JobListViewModel } from "@/viewmodels.g";

const onboarding = ref(0);

const job = new JobViewModel();
const show = ref(false)

const loadJob = async () => {
  await job.$load();
};

onMounted(loadJob);

const loadJobs = async () => {
  
  await job.$load(jobList.$items[0]);
};

watch(onboarding, loadJobs);

const jobList = new JobListViewModel();
const length = ref(0);
const loadJobList = async () => {
  await jobList.$load();
  await jobList.$count();
  length.value = jobList.$count.result;
};

onMounted(loadJobList);
</script>

<script>
  export default {
    data: () => ({
      show: false,
    }),
  }
</script>