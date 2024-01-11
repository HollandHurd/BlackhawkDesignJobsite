<template>
  <h1 align="center" class="mx-auto my-1">Job Listings</h1>
  <h2 align="center">Welcome</h2>
  <div class="welcome">
    
  </div>
  <h3 align="center">Search:</h3>
  <v-text-field
  label="Search"
  class="searchbar"
  align="center"
  ></v-text-field>

  <v-row align="center" justify="center">
    
    <div v-for="item of jobList.$items">
    <v-col cols="auto">
      
        
      
      <v-card
    class="mx-auto my-8"
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
      Posting Date: 01/11/2024
    </v-card-subtitle>

    <v-card-subtitle>
      Description: {{  item.jobDesc }}
    </v-card-subtitle>

    <v-card-actions>
      <v-btn
        color="primary"
        variant="flat"
        href="/apply"
      >
        Apply
      </v-btn>

      <v-spacer></v-spacer>
      
      
      <v-btn
        color="primary"
        variant="tonal"
        href="/jobs"
      >
        Read More
      </v-btn>
    </v-card-actions>

  </v-card>
      
    </v-col>
  </div>
  </v-row>
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

<style>
  .searchbar {
    width: 300px;
  }
</style>
