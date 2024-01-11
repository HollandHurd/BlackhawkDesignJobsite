<template>

  <v-parallax
    src="https://cdn.vuetifyjs.com/images/parallax/material.jpg"
  >
    <div class="d-flex flex-column fill-height justify-center align-center text-white">
      
      <h1 class="test">
        Blackhawk Design
        <img src="../assets/logo.png"
             width="64"
             height="64"
             alt="Blackhawk Design Logo" />
      </h1>
      <h4 class="subheading">
        Empowering the body of CHS!
      </h4>
    </div>
  </v-parallax>
  
  <div class="mission">

    <v-card
    class="mx-auto my-12"
    max-width="300"
    
  >

    <v-img
      cover
      height=250
      src="../assets/missionStatement.png"
    ></v-img>

    <v-card-item>
      <v-card-title>Our Mission</v-card-title>
    </v-card-item>

    <v-card-text>
      This website is mainly used for the student body of Cheney High School.
      Our primary objective is to provide students the opportunity to look at available jobs and learn how they can benefit from our resources.
      We evaluate who fits the qualifications for our jobs based on job screenings and skill checks as a precaution to better our business and quality of production.
    </v-card-text>


  </v-card>
  </div>
  <div class="collaborations">
    - Worked with Cheney High School
    - Worked with Cheney Middle School
    
  </div>
  <div class="subscription">
    Haven't we convinced you enough subscribe to get email on latest job updates!
    - Name
    - Email 
    Submit
  </div>
  <div class="skills">
    <v-row align="center" justify="center">
    <v-col cols="auto">
      <v-card
        class="mx-auto"
        max-width="344"
        title="Icons"
        subtitle="prepend-icon and append-icon"
        prepend-icon="mdi-account"
        append-icon="mdi-check"
      >
        <v-card-text>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod.</v-card-text>
      </v-card>
    </v-col>

    <v-col cols="auto">
      <v-card
        class="mx-auto"
        max-width="344"
        title="Icons"
        subtitle="prepend and append"
      >
        <template v-slot:prepend>
          <v-icon icon="mdi-account" color="primary"></v-icon>
        </template>
        <template v-slot:append>
          <v-icon icon="mdi-check" color="success"></v-icon>
        </template>
        <v-card-text>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod.</v-card-text>
      </v-card>
    </v-col>

    <v-col cols="auto">
      <v-card
        class="mx-auto"
        max-width="344"
        title="Avatars"
        subtitle="prepend-avatar and append-avatar"
        prepend-avatar="https://cdn.vuetifyjs.com/images/logos/v-alt.svg"
        append-avatar="https://cdn.vuetifyjs.com/images/john.jpg"
      >
        <v-card-text>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod.</v-card-text>
      </v-card>
    </v-col>

    <v-col cols="auto">
      <v-card
        class="mx-auto"
        max-width="344"
        title="Avatars"
        subtitle="prepend and append"
      >
        <template v-slot:prepend>
          <v-avatar color="blue-darken-2">
            <v-icon icon="mdi-alarm"></v-icon>
          </v-avatar>
        </template>
        <template v-slot:append>
          <v-avatar size="24">
            <v-img
              src="https://cdn.vuetifyjs.com/images/john.png"
              alt="John"
            ></v-img>
          </v-avatar>
        </template>
        <v-card-text>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod.</v-card-text>
      </v-card>
    </v-col>
    
  </v-row>
  </div>
  <div class="faq">
    <h1 align="center">Frequently Asked Questions</h1>
    <v-expansion-panels variant="popout" class="my-4">
      <v-expansion-panel
        v-for="i in 3"
        :key="i"
        title="Item"
        text="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat."
      ></v-expansion-panel>
    </v-expansion-panels>
    
  </div>
</template>

<script setup lang="ts">
useTitle("Home");
</script>

<style setup="scss">


.home {
  height: 1080px;
  text-align: center;

}

.mission {
  height: 550px;
}

.test {
  font-family: 'Times New Roman', Times, serif
}


</style>
