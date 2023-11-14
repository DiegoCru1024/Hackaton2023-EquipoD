import ScheduleComponent from "../groupComponent/subcomponents/scheduleComponent";

export default function ScheduleViewComponent() {

    return (
        <div className={'componentContainer'}>
            <h1>Vista de Horarios</h1>
            <ScheduleComponent blockedHours={[]} selectedObject={{indexes: [], labels: []}}/>
        </div>
    )
}