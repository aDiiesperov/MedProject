<template>
  <div v-if="configs && configs.length">
    <table class="table table-hover table-striped">
      <thead class="text-center">
        <tr>
          <th
            v-for="config in configs"
            :key="config.prop"
            class="position-relative"
            :class="{
              sortable: config.sortable,
              'sort-desc': config.prop === sortBy && sortDir === 'desc',
              'sort-asc': config.prop === sortBy && sortDir === 'asc',
            }"
            :style="{ width: config.width + 'px' }"
            @click="config.sortable && onSort(config.prop)"
          >
            <p>
              {{ config.name || config.prop | capitalize }}
            </p>
          </th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="item in currentItems" :key="item.id">
          <td
            class="text-center px-3"
            v-for="config in configs"
            :key="config.name || config.prop"
            :style="{ width: config.width + 'px' }"
          >
            <component
              v-if="config.component"
              :is="config.component"
              :item="item"
            ></component>
            <app-buttons-cell
              v-else-if="config.type === 'button'"
              :config="config"
              :item="item"
            ></app-buttons-cell>
            <p v-else-if="config.type === 'date'">
              {{ item[config.prop] | formatDate }}
            </p>
            <p v-else>
              {{
                config.valueResolver
                  ? config.valueResolver(item)
                  : item[config.prop] | nullToDash
              }}
            </p>
          </td>
        </tr>
      </tbody>
    </table>

    <app-pagination
      @pageChanged="pageChanged($event)"
      :curPage="page"
      :totalPages="totalPages"
    ></app-pagination>
  </div>
</template>

<script>
import AppPagination from "./AppPagination.vue";
import AppButtonsCell from "./cells/AppButtonsCell.vue";
import { orderBy } from "lodash";
import { QueryHelper } from "@/helpers";

export default {
  components: { AppPagination, AppButtonsCell },
  props: {
    configs: {
      typeof: Array,
      required: true,
    },
    data: {
      typeof: Array,
      required: true,
    },
  },
  data: () => ({
    sortBy: "",
    sortDir: "",
    page: 1,
    pageSize: 10,
  }),
  created() {
    this.setupParams();
  },
  computed: {
    currentItems() {
      if (!this.data?.length) return [];
      const startPos = (this.page - 1) * this.pageSize;
      const data = orderBy(this.data, [this.sortBy], [this.sortDir]);
      return data.slice(startPos, startPos + this.pageSize);
    },
    totalPages() {
      return this.data?.length
        ? Math.ceil(this.data.length / this.pageSize)
        : 0;
    },
  },
  methods: {
    setupParams() {
      this.page = +this.$route.query.page || 1;
      this.sortBy = this.$route.query.sortBy;
      this.sortDir = this.$route.query.sortDir;
    },
    pageChanged(page) {
      this.page = page;
      QueryHelper.updateQuery(this.$route, this.$router, { page: +page || 1 });
    },
    onSort(prop) {
      if (this.sortBy === prop) {
        this.sortDir = this.sortDir === "asc" ? "desc" : "asc";
      } else {
        this.sortBy = prop;
        this.sortDir = "asc";
      }
      const newParams = { sortBy: this.sortBy, sortDir: this.sortDir };
      QueryHelper.updateQuery(this.$route, this.$router, newParams);
    },
  },
};
</script>

<style lang="scss" scoped>
@import "AppTable";
</style>
