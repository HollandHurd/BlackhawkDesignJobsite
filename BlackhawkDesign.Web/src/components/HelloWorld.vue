<template>
  <v-parallax src="https://cdn.vuetifyjs.com/images/backgrounds/vbanner.jpg">
    <div
      class="d-flex flex-column fill-height justify-center align-center text-white"
    >
      <h1 class="text-h4 font-weight-thin mb-4">
        Blackhawk Design
        <img
          src="../assets/logo.png"
          width="64"
          height="64"
          alt="Blackhawk Design Logo"
        />
      </h1>

      <h4 class="subheading">cooper is hot</h4>
    </div>
  </v-parallax>
</template>

<script setup lang="ts">
defineProps<{ msg: string | null }>();
</script>
