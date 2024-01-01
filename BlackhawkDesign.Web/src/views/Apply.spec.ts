import { mount, flushPromises, mockEndpoint } from "@/test-utils";
import { VTextField } from "vuetify/components";
import Apply from "./Apply.vue";
import { Application } from "@/models.g";

describe("Apply.vue", () => {
  it("Saves/Creates an application", async () => {
    // Arrange
    mockEndpoint("/Application/get/3", () => ({
      wasSuccessful: true,
      object: { applicationId: 3, firstName: "", lastName: "", appliedFor: "", applied: null } as Application,
    }));

    // Act
    const wrapper = mount(Apply);
    await flushPromises();

    // Assert
    expect(wrapper.text()).toMatch("Creating New Application");
    expect(document.title).toMatch("New Application");
    expect(wrapper.findComponent(VTextField).vm.modelValue).toBe(""); // Adjust this based on your actual initial values for a new application.

    // Ensure that $load is not called during creation
    expect(wrapper.vm.$data.user.$load).not.toHaveBeenCalled();
  });
});
