<template>
  <div>
    <v-container class="mx-auto">
      <v-expansion-panels variant="accordion">
      <v-expansion-panel
        v-for="auctaljob in jobList.$items"
        :key="i"
        :title=auctaljob.jobName
        text="back" 
      >
    </v-expansion-panel>

    </v-expansion-panels>
    </v-container>
  </div>
  <Footer></Footer>
</template>

<script setup>
import { ref, watch, onMounted } from "vue";
import { JobViewModel, JobListViewModel } from "@/viewmodels.g";

const onboarding = ref(0);

const job = new JobViewModel();

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
