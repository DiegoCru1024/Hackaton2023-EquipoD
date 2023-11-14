import MessageFacade from "../../facades/messageFacade";

export default function ScheduleViewComponent() {
    const messageFacade = new MessageFacade()

    return (
        <div className={'componentContainer'}>
            <h1>Vista de Horarios</h1>
            <button onClick={() => messageFacade.debug()}>DEBUG</button>
        </div>
    )
}