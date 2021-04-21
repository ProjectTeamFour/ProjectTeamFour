const announcement = new Vue({
    el: "#announcement",
    data: {
        Model: {
            Title:'',
            Content: '',
            MemberId:'48',
        },
        items: [],
        fields: [
            { key: 'announcementId', label: '編號', sortable: true },
            { key: 'memberId', label: '會員編號', sortable: true },
            { key: 'title', label: '通知標題', class: '' },
            { key: 'createTime', label: '發布時間', class: '' },
            { key: 'createUser', label: '發布人', class: '' },
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
        
        info(item, index, button) {
            this.infoModal.title = `標題: ${JSON.stringify(item.title, null, 2)}`
            this.infoModal.id = `編號:${JSON.stringify(item.announcementId, null, 2)}\n\n`
            this.infoModal.MemberId = `會員編號:${JSON.stringify(item.memberId,null,2)}\n\n`
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
        saveSuccess(variant = primary) {
            this.$bvToast.toast('修改成功!已儲存', {
                title: `修改成功` ,
                variant: variant,
                solid: true
            })
        },
        saveError(variant = danger) {
            this.$bvToast.toast('修改失敗!請聯絡客服人員', {
                title: `修改失敗`,
                variant: variant,
                soild: true
            })
        },
        removeSuccess(variant = primary) {
            this.$bvToast.toast('刪除成功!', {
                title: `刪除成功`,
                variant: variant,
                solid: true
            })
        },
        removeError(variant = danger) {
            this.$bvToast.toast('刪除失敗!請聯絡客服人員', {
                title: `刪除失敗`,
                variant: variant,
                solid: true
            })
        },
        clearModel() {
            this.Model.Title = '';
            this.Model.Content = '';
        }, getAnnouncement() {
            axios.get("/Api/Announcements/GetAll")
                .then((res) => {
                    this.items = res.data.body.myAnnouncementList;
                    this.mounted();
                    this.isBusy = false;
                });
        },
        editAnnouncement(data, index, button) {
            console.log(data.title);
            this.Model.announcementId = data.announcementId;
            this.Model.Title = data.title;
            this.Model.Content = data.content;
            this.$bvModal.show('edit-announcement');
        },
        saveAnnouncement() {
            axios.put("/Api/Announcements/SaveAnnouncement", this.Model)
                .then(res => {
                    this.saveSuccess('primary');
                    this.getAnnouncement();
                    this.clearModel();
                })
                .catch(error => {
                    this.saveError('danger');
                })
        },
        createAnnouncement() {
            axios.post("/Api/Announcements/CreateAnnouncement", this.Model)
                .then(res => {
                    this.createSuccess('primary');
                    this.getAnnouncement();
                    this.clearModel();
                })
                .catch(error => {
                    this.createError('danger');
                });
        },
        removeAnnouncement(data, index, button) {
            this.Model.announcementId = data.announcementId;
            axios.delete("/Api/Announcements/DeleteAnnouncement", {
                data: {
                    'AnnouncementId': data.announcementId
                }
            })
                .then(res => {
                    this.removeSuccess('primary');
                    this.getAnnouncement();
                })
                .catch(error => {
                    this.removeError('danger');
                    console.table(error);
                })
        },
    },
});