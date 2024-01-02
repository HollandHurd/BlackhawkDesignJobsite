<template>
  <div>
    <v-container class="mb-6">
      <v-row align="center" no-gutters style="height: 150px">
        <v-col v-for="n in 1" :key="n"> </v-col>

        <v-col v-for="n in 1" :key="n">
          <v-sheet class="pa-2 ma-2">
            <CreateApplication
              v-model="newAppDialog"
              :app="newApp"
              @saved="loadApps"
            />
          </v-sheet>
        </v-col>
        <v-col v-for="n in 1" :key="n"> </v-col>
      </v-row>
    </v-container>
  </div>
</template>

<script setup lang="ts">
import { ApplicationViewModel } from "@/viewmodels.g";

const newAppDialog = ref(false);
let newApp = new ApplicationViewModel();

loadApps();

function loadApps() {
  newApp = new ApplicationViewModel();
}
</script>
