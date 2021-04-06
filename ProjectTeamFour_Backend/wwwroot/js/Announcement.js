const announcement = new Vue({
    el: "#announcement",
    data: {
        Model: {
            Title:'',
            Content: '',
            MemberId:263
        },
        items: [],
        fields: [
            { key: 'announcementId', label: '編號', sortable: true },
            { key: 'title', label: '通知標題', class: '' },
            { key: 'createTime', label: '發布時間', class: '' },
            { key: 'createUser', label: '發布人', class: '' },
            { key: 'editTime', label: '編輯時間', class: '' },
            { key: 'editUser', label: '編輯人', class: '' },
            { key: 'actions', label:'功能'}
        ],
        isError: false,
        isBusy: true,
        totalRows: 1,
        currentPage: 1,
        perPage: 20,
        pageOptions: [5, 10, 20, { value: 100, text: "100" }],
        sortBy: '',
        sortDesc: false,
        sortDirection: 'asc',
        filter: null,
        filterOn: [],
        infoModal: {
            id: 'info-modal',
            title: '',
            content: ''
        }
    },
    created: function(){
        this.getAnnouncement();
    },
    computed: {
        sortOptions() {
            // Create an options list from our fields
            return this.fields
                .filter(f => f.sortable)
                .map(f => {
                    return { text: f.label, value: f.key }
                })
        }
    },
    mounted() {
        // Set the initial number of items
        this.totalRows = this.items.length
    },
    methods: {
        getAnnouncement() {
            axios.get("/Api/Announcements/GetAll")
                .then((res) => {
                    this.items = res.data.body.myAnnouncementList;
                    this.mounted();
                    this.isBusy = false;
                });
        },
        editAnnouncement(item, index, button,data) {
            this.clearModel();
            for (const key in this.Model) {
                this.Model[key] = data[Key] ?? '';
            }
            this.Model.Title = data.Title;
            this.Model.Content = data.Content;
            this.$bvModal.show('edit-announcement');
            console.log(this.item);
        },
        saveAnnouncement() {

            axios.put('/Api/Announcement/UpdateAccount',this.Model)
                .then(res => {
                })
        },
        createAnnouncement() {
            console.log(this.Model);
            axios.post("/Api/Announcements/CreateAnnouncement", this.Model)
                .then(res => {
                    this.createSuccess('primary');
                    this.getAnnouncement();
                })
                .catch(error => {
                    this.createError('danger');
                });
        },
        removeAnnouncement(item, index, button) {
            console.log("123");
            /*axios.delete(`/Api/Announcements/DeleteAnnouncement?announcementId=${this.index}`);*/
        },
        info(item, index, button) {
            this.infoModal.title = `編號: ${JSON.stringify(item.announcementId, null, 2)}`
            this.infoModal.id = `編號:${JSON.stringify(item.announcementId, null, 2)}\n\n`
            this.infoModal.content = `\n${JSON.stringify(item.content, null, 0)}\n\n`
            this.infoModal.createTime = `\n發布時間:${JSON.stringify(item.createTime, null, 2)}\n\n`
            this.infoModal.createUser = `發布人:${JSON.stringify(item.createUser, null, 2)}\n\n`
            this.infoModal.editTime = `編輯時間:${JSON.stringify(item.editTime, null, 2)}\n\n`
            this.infoModal.editUser = `編輯人:${JSON.stringify(item.editUser, null, 2)}\n\n`
            this.$root.$emit('bv::show::modal', this.infoModal.id, button)
        },
        resetInfoModal() {
            this.infoModal.title = ''
            this.infoModal.content = ''
        },
        onFiltered(filteredItems) {
            // Trigger pagination to update the number of buttons/pages due to filtering
            this.totalRows = filteredItems.length
            this.currentPage = 1
        },
        mounted() {
            // Set the initial number of items
            this.totalRows = this.items.length
        },
        createSuccess(variant = primary) {
            this.$bvToast.toast('最新消息已發布成功!', {
                title: `發布成功`,
                variant: variant,
                solid: true
            })
        },
        createError(variant = danger) {
            this.$bvToast.toast('請聯絡服務人員', {
                title: `發布失敗`,
                variant: variant,
                solid: true
            })
        },
        clearModel() {
            this.Model.Title = '';
            this.Model.Content = '';
        }
    },
});