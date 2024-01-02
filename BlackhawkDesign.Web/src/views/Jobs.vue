<template>
  <div>
    <v-container class="mb-6 mx-auto">
      <v-row align="center" no-gutters style="height: 150px">
        <v-col v-for="n in 1" :key="n">
          <v-sheet class="align"> </v-sheet>
          <h1>Why apply?</h1>
          
        </v-col>

        <v-col v-for="n in 1" :key="n">
          <v-sheet class="pa-2 ma-2">
            <v-window v-model="onboarding" show-arrows>
              <v-window-item
                v-for="auctaljob in jobList.$items"
                :key="`card-${window}`"
              >
                <v-card elevation="5" class="ma-2">
                  <v-img
                    class="align-end text-white"
                    height="300"
                    :src="auctaljob.jobImage"
                    cover
                  ></v-img>

                  <h1 class="headline font-weight-heavy my-3 align-center">
                    {{ auctaljob.jobName }}
                  </h1>
                  <h2 class="headline font-weight-light my-3">
                    Job Description
                  </h2>
                  {{ auctaljob.jobDesc }}
                  <v-divider thickness="5"></v-divider>
                  <h2 class="headline font-weight-light my-3">Benefits</h2>
                  <ul>
                    <li
                      v-for="(benefit, index) in auctaljob.jobBenefit
                        ? auctaljob.jobBenefit.split(';')
                        : []"
                      :key="index"
                    >
                      {{ benefit.trim() }}
                    </li>
                  </ul>
                </v-card>
              </v-window-item>
            </v-window>
          </v-sheet>
        </v-col>
        <v-col v-for="n in 0" :key="n">
          <v-sheet class="pa-2 ma-2"> </v-sheet>
        </v-col>
      </v-row>
    </v-container>
  </div>
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
